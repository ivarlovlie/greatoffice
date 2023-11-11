global using System;
global using System.Linq;
global using System.IO;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Collections.Generic;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Security.Claims;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using IOL.GreatOffice.Api.Models.Database;
global using IOL.GreatOffice.Api.Models.Enums;
global using IOL.GreatOffice.Api.Models.Models;
global using IOL.GreatOffice.Api.Models.Static;
global using IOL.GreatOffice.Api.Services;
global using IOL.GreatOffice.Api.Resources;
global using IOL.GreatOffice.Api.Utilities;
global using IOL.Helpers;
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Authentication.Cookies;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.DataProtection;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Localization;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Serilog;
global using Quartz;
using IOL.GreatOffice.Api.Endpoints.V1;
using IOL.GreatOffice.Api.Jobs;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Versioning;
using Serilog.Events;

namespace IOL.GreatOffice.Api;

public static class Program
{
    private static readonly string[] supportedCultures = ["en", "nb"];
    public static AppConfiguration AppConfiguration { get; set; }
    public static WebApplicationBuilder CreateAppBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddLogging();
        builder.Services.AddHttpClient();
        builder.Services.AddMemoryCache();
        builder.Services.AddScoped<MailService>();
        builder.Services.AddScoped<PasswordResetService>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<TenantService>();
        builder.Services.AddScoped<EmailValidationService>();
        builder.Services.AddHttpClient<MailService>();

        AppConfiguration = new AppConfiguration(builder.Configuration);

        var logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .WriteTo.Console();

        if (!builder.Environment.IsDevelopment() && AppConfiguration.SEQ_API_KEY.HasValue() && AppConfiguration.SEQ_API_URL.HasValue())
        {
            logger.WriteTo.Seq(AppConfiguration.SEQ_API_URL, apiKey: AppConfiguration.SEQ_API_KEY);
        }

        Log.Logger = logger.CreateLogger();
        Log.Information("Starting web host, " + JsonSerializer.Serialize(AppConfiguration.GetPublicObject(), JsonSettings.WriteIndented));

        builder.Host.UseSerilog(Log.Logger);

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddCors();
        }

        if (builder.Environment.IsProduction())
        {
            builder.Services.Configure<ForwardedHeadersOptions>(options => { options.ForwardedHeaders = ForwardedHeaders.XForwardedProto; });
        }

        builder.Services.AddLocalization();
        builder.Services.AddRequestLocalization(options =>
        {
            options.SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);
            options.ApplyCurrentCultureToResponseHeaders = true;
        });

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
                // Get culture from specific cookie
                await Task.FromResult(new ProviderCultureResult(context.Request.Cookies[AppCookies.Locale] ?? "en")))
            );
        });

        builder.Services
            .AddDataProtection()
            .ProtectKeysWithCertificate(AppConfiguration.CERT1())
            .PersistKeysToDbContext<MainAppDatabase>();

        builder.Services.Configure(JsonSettings.SetDefaultAction);
        builder.Services.AddQuartz(options =>
        {
            options.UsePersistentStore(o =>
            {
                o.UsePostgres(AppConfiguration.GetQuartzDatabaseConnectionString());
                o.UseSerializer<QuartzJsonSerializer>();
            });

            options.RegisterJobs();
        });

        builder.Services.AddQuartzHostedService(options => { options.WaitForJobsToComplete = true; });
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
            .AddCookie(options =>
            {
                options.Cookie.Name = AppCookies.Session;
                options.Cookie.Domain = builder.Environment.IsDevelopment() ? "localhost" : ".greatoffice.app";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.SlidingExpiration = true;
                options.Events.OnRedirectToAccessDenied =
                    options.Events.OnRedirectToLogin = c =>
                    {
                        c.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.FromResult<object>(null);
                    };
            })
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(AppConstants.BASIC_AUTH_SCHEME, default);

        builder.Services.AddDbContext<MainAppDatabase>(options =>
        {
            options.UseNpgsql(AppConfiguration.GetAppDatabaseConnectionString(),
                    npgsqlDbContextOptionsBuilder =>
                    {
                        npgsqlDbContextOptionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        npgsqlDbContextOptionsBuilder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), default);
                    })
                .UseSnakeCaseNamingConvention();
            if (builder.Environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
            }
        });

        builder.Services.AddApiVersioning(options =>
        {
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = false;
        });
        builder.Services.AddVersionedApiExplorer(options => { options.SubstituteApiVersionInUrl = true; });
        builder.Services.AddSwaggerGen(options =>
        {
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "IOL.GreatOffice.Api.xml"));
            options.UseApiEndpoints();
            options.OperationFilter<SwaggerDefaultValues>();
            options.OperationFilter<PaginationOperationFilter>();
            options.SwaggerDoc(ApiSpecV1.Document.VersionName, ApiSpecV1.Document.OpenApiInfo);
            options.AddSecurityDefinition("Basic",
                new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Basic",
                    BearerFormat = "Basic",
                    In = ParameterLocation.Header,
                    Description =
                        "Enter your token in the text input below.\r\n\r\nExample: \"Basic 12345abcdef\"",
                });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Basic"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        builder.Services.AddPagination(options =>
        {
            options.DefaultSize = 50;
            options.MaxSize = 100;
            options.CanChangeSizeFromQuery = true;
        });

        builder.Services
            .AddControllers()
            .AddDataAnnotationsLocalization()
            .AddJsonOptions(JsonSettings.SetDefaultAction);

        return builder;
    }

    public static WebApplication CreateWebApplication(WebApplicationBuilder builder)
    {
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseCors(cors =>
            {
                cors.AllowAnyMethod();
                cors.AllowAnyHeader();
                cors.SetIsOriginAllowed(_ => true);
                cors.AllowCredentials();
                cors.WithExposedHeaders(AppHeaders.IS_KNOWN_PROBLEM);
            });
        }

        if (app.Environment.IsProduction())
        {
            app.UseForwardedHeaders();
        }

        app.UseDefaultFiles()
            .UseStaticFiles()
            .UseRequestLocalization()
            .UseRouting()
            .UseSerilogRequestLogging()
            .UseStatusCodePages()
            .UseAuthentication()
            .UseAuthorization()
            .UseSwagger()
            .UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(ApiSpecV1.Document.SwaggerPath, ApiSpecV1.Document.VersionName);
                options.DocumentTitle = AppConstants.API_NAME;
            })
            .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        return app;
    }

    public static int Main(string[] args)
    {
        try
        {
            CreateWebApplication(CreateAppBuilder(args)).Run();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Unhandled exception");
            return 1;
        }
        finally
        {
            Log.Information("Shut down complete, flushing logs...");
            Log.CloseAndFlush();
        }
    }
}