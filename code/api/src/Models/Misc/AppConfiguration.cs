using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace IOL.GreatOffice.Api.Models.Misc;

public class AppConfiguration
{
    public AppConfiguration()
    {

    }

    public AppConfiguration(IConfiguration c)
    {
        DB_HOST = c.GetValue<string>(nameof(DB_HOST));
        DB_PORT = c.GetValue<string>(nameof(DB_PORT));
        DB_NAME = c.GetValue<string>(nameof(DB_NAME));
        DB_USER = c.GetValue<string>(nameof(DB_USER));
        DB_PASSWORD = c.GetValue<string>(nameof(DB_PASSWORD));
        QUARTZ_DB_HOST = c.GetValue<string>(nameof(QUARTZ_DB_HOST));
        QUARTZ_DB_NAME = c.GetValue<string>(nameof(QUARTZ_DB_NAME));
        QUARTZ_DB_PASSWORD = c.GetValue<string>(nameof(QUARTZ_DB_PASSWORD));
        QUARTZ_DB_USER = c.GetValue<string>(nameof(QUARTZ_DB_USER));
        QUARTZ_DB_PORT = c.GetValue<string>(nameof(QUARTZ_DB_PORT));
        APP_CERT = c.GetValue<string>(nameof(APP_CERT));
        APP_AES_KEY = c.GetValue<string>(nameof(APP_AES_KEY));
        SEQ_API_KEY = c.GetValue<string>(nameof(SEQ_API_KEY));
        SEQ_API_URL = c.GetValue<string>(nameof(SEQ_API_URL));
        POSTMARK_TOKEN = c.GetValue<string>(nameof(POSTMARK_TOKEN));
        EMAIL_FROM_ADDRESS = c.GetValue<string>(nameof(EMAIL_FROM_ADDRESS));
        CANONICAL_FRONTEND_URL = c.GetValue<string>(nameof(CANONICAL_FRONTEND_URL));
        CANONICAL_BACKEND_URL = c.GetValue<string>(nameof(CANONICAL_BACKEND_URL));
        ASPNETCORE_ENVIRONMENT = c.GetValue<string>(nameof(ASPNETCORE_ENVIRONMENT));
        _configuration = c;
    }

    private static IConfiguration _configuration { get; set; }

    /// <summary>
    /// An reachable ip address or url that points to a postgres database.
    /// </summary>
    public string DB_HOST { get; set; }

    /// <summary>
    /// The port number to use with DB_HOST to point to the postgres database.
    /// </summary>
    public string DB_PORT { get; set; }

    /// <summary>
    /// The database user to authenticate against postgres with.
    /// </summary>
    public string DB_USER { get; set; }

    /// <summary>
    /// The password for the database user to authenticate against postgres with.
    /// </summary>
    public string DB_PASSWORD { get; set; }

    /// <summary>
    /// The name of the main app database.
    /// </summary>
    public string DB_NAME { get; set; }

    /// <summary>
    /// An reachable ip address or url that points to a postgres(quartz) database.
    /// </summary>
    public string QUARTZ_DB_HOST { get; set; }

    /// <summary>
    /// The port number to use with QUARTZ_DB_HOST to point to the postgres(quartz) database.
    /// </summary>
    public string QUARTZ_DB_PORT { get; set; }

    /// <summary>
    /// The database user to authenticate against postgres(quartz) with.
    /// </summary>
    public string QUARTZ_DB_USER { get; set; }

    /// <summary>
    /// The password for the database user to authenticate against postgres(quartz) with.
    /// </summary>
    public string QUARTZ_DB_PASSWORD { get; set; }

    /// <summary>
    /// The name of the quartz database.
    /// </summary>
    public string QUARTZ_DB_NAME { get; set; }

    /// <summary>
    /// API key to use when pushing logs to SEQ
    /// </summary>
    public string SEQ_API_KEY { get; set; }

    /// <summary>
    /// Url pointing to the seq instance that processes server logs
    /// </summary>
    public string SEQ_API_URL { get; set; }

    /// <summary>
    /// A token used when sending email via Postmakr
    /// </summary>
    public string POSTMARK_TOKEN { get; set; }

    /// <summary>
    /// The address to send emails from, needs to be setup as a sender in postmark
    /// </summary>
    public string EMAIL_FROM_ADDRESS { get; set; }

    /// <summary>
    /// The absolute url to the frontend app
    /// </summary>
    public string CANONICAL_FRONTEND_URL { get; set; }

    /// <summary>
    /// The absolute url to the backend api
    /// </summary>
    public string CANONICAL_BACKEND_URL { get; set; }

    /// <summary>
    /// A random string used to encrypt/decrypt for general purposes
    /// </summary>
    public string APP_AES_KEY { get; set; }

    /// <summary>
    /// A base64 string containing a passwordless pfx cert
    /// </summary>
    public string APP_CERT { get; set; }

    /// <summary>
    /// A string signaling to the framework what environment it is running in, usually Development, Testing or Production.
    /// </summary>
    public string ASPNETCORE_ENVIRONMENT { get; set; }

    public X509Certificate2 CERT1() => new(Convert.FromBase64String(APP_CERT));

    public object GetPublicObject()
    {
        return new
        {
            DB_HOST,
            DB_PORT,
            DB_USER,
            DB_PASSWORD = DB_PASSWORD.Obfuscate(),
            QUARTZ_DB_HOST,
            QUARTZ_DB_PORT,
            QUARTZ_DB_USER,
            QUARTZ_DB_PASSWORD = QUARTZ_DB_PASSWORD.Obfuscate(),
            SEQ_API_KEY = SEQ_API_KEY.Obfuscate(),
            SEQ_API_URL,
            POSTMARK_TOKEN = POSTMARK_TOKEN.Obfuscate(),
            EMAIL_FROM_ADDRESS,
            APP_AES_KEY = APP_AES_KEY.Obfuscate(),
            CERT1 = CERT1().Thumbprint,
            CANONICAL_FRONTEND_URL,
            ASPNETCORE_ENVIRONMENT
        };
    }

    public string GetEnvironmentVariable(string variableName, string fallback = "")
    {
        if (_configuration == default)
        {
            Debug.WriteLine("AppConfiguration was instantiated without a full IConfiguration");
            return "";
        }
        if (fallback.HasValue()) return _configuration.GetValue(variableName, fallback);
        return _configuration.GetValue<string>(variableName);
    }

    public string GetAppDatabaseConnectionString()
    {
        var builder = new StringBuilder();

        builder.Append($"Server={DB_HOST};Port={DB_PORT};Database={DB_NAME};User Id={DB_USER};Password={DB_PASSWORD}");

        if (ASPNETCORE_ENVIRONMENT == "Development")
        {
            builder.Append(";Include Error Detail=true");
        }

        Log.Debug("Using app database connection string: " + builder.ToString());
        return builder.ToString();
    }

    public string GetQuartzDatabaseConnectionString()
    {
        var builder = new StringBuilder();

        builder.Append($"Server={QUARTZ_DB_HOST};Port={QUARTZ_DB_PORT};Database={QUARTZ_DB_NAME};User Id={QUARTZ_DB_USER};Password={QUARTZ_DB_PASSWORD}");

        if (ASPNETCORE_ENVIRONMENT == "Development")
        {
            builder.Append(";Include Error Detail=true");
        }

        Log.Debug("Using quartz database connection string: " + builder.ToString());
        return builder.ToString();
    }

    public string GetAppVersion()
    {
        var versionFilePath = Path.Combine(AppPaths.AppData.HostPath, "version.txt");
        if (!File.Exists(versionFilePath)) return "unknown-" + ASPNETCORE_ENVIRONMENT;
        var versionText = File.ReadAllText(versionFilePath);
        return versionText + "-" + ASPNETCORE_ENVIRONMENT;
    }
}