namespace IOL.GreatOffice.Api.Utilities;

public static class ConfigurationExtensions
{
	public static string GetAppDatabaseConnectionString(this IConfiguration config, AppConfiguration configuration) {
		var host = configuration.DB_HOST;
		var port = configuration.DB_PORT;
		var database = configuration.DB_NAME;
		var user = configuration.DB_USER;
		var password = configuration.DB_PASSWORD;

		string result;
		if (config.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "Development") {
			result = $"Server={host};Port={port};Database={database};User Id={user};Password={password};Include Error Detail=true";
		} else {
			result = $"Server={host};Port={port};Database={database};User Id={user};Password={password}";
		}

		Log.Debug("Using app database connection string: " + result);
		return result;
	}

	public static string GetAppDatabaseConnectionString(this IConfiguration config, Func<AppConfiguration> configuration) {
		var _configuration = configuration();
		var host = _configuration.DB_HOST;
		var port = _configuration.DB_PORT;
		var database = _configuration.DB_NAME;
		var user = _configuration.DB_USER;
		var password = _configuration.DB_PASSWORD;

		string result;
		if (config.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "Development") {
			result = $"Server={host};Port={port};Database={database};User Id={user};Password={password};Include Error Detail=true";
		} else {
			result = $"Server={host};Port={port};Database={database};User Id={user};Password={password}";
		}

		Log.Debug("Using app database connection string: " + result);
		return result;
	}

	public static string GetQuartzDatabaseConnectionString(this IConfiguration config, AppConfiguration configuration) {
		var host = configuration.QUARTZ_DB_HOST;
		var port = configuration.QUARTZ_DB_PORT;
		var database = configuration.QUARTZ_DB_NAME;
		var user = configuration.QUARTZ_DB_USER;
		var password = configuration.QUARTZ_DB_PASSWORD;

		string result;
		if (config.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "Development") {
			result = $"Server={host};Port={port};Database={database};User Id={user};Password={password};Include Error Detail=true";
		} else {
			result = $"Server={host};Port={port};Database={database};User Id={user};Password={password}";
		}

		Log.Debug("Using quartz database connection string: " + result);
		return result;
	}

	public static string GetQuartzDatabaseConnectionString(this IConfiguration config, Func<AppConfiguration> configuration) {
		var _configuration = configuration();
		var host = _configuration.QUARTZ_DB_HOST;
		var port = _configuration.QUARTZ_DB_PORT;
		var database = _configuration.QUARTZ_DB_NAME;
		var user = _configuration.QUARTZ_DB_USER;
		var password = _configuration.QUARTZ_DB_PASSWORD;

		string result;
		if (config.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "Development") {
			result = $"Server={host};Port={port};Database={database};User Id={user};Password={password};Include Error Detail=true";
		} else {
			result = $"Server={host};Port={port};Database={database};User Id={user};Password={password}";
		}

		Log.Debug("Using quartz database connection string: " + result);
		return result;
	}

	public static string GetVersion(this IConfiguration configuration) {
		var versionFilePath = Path.Combine(AppPaths.AppData.HostPath, "version.txt");
		if (!File.Exists(versionFilePath)) return "unknown-" + configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT");
		var versionText = File.ReadAllText(versionFilePath);
		return versionText + "-" + configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT");
	}
}
