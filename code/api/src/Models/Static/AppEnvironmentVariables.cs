namespace IOL.GreatOffice.Api.Data.Static;

public static class AppEnvironmentVariables
{
    /// <summary>
    /// An access token that can be used to access the Hashicorp Vault instance that is available at VAULT_URL
    /// </summary>
    public const string VAULT_TOKEN = "VAULT_TOKEN";

    /// <summary>
    /// A url pointing to the Hashicorp Vault instance the app should use
    /// </summary>
    public const string VAULT_URL = "VAULT_URL";

    /// <summary>
    /// The duration of which to keep a local cached version of the configuration
    /// </summary>
    public const string VAULT_CACHE_TTL = "VAULT_CACHE_TTL";

    /// <summary>
    /// The vault key name for the main configuration json object, described by <see cref="AppConfiguration"/> 
    /// </summary>
    public const string MAIN_CONFIG_SHEET = "MAIN_CONFIG_SHEET";

    /// <summary>
    /// Tells the api to enable flight mode, only acts in DEBUG
    /// </summary>
    public const string FLIGHT_MODE = "FLIGHT_MODE";

    /// <summary>
    /// Tells the api where to read configuration from, defaults to flightmode.json, only acts in DEBUG
    /// </summary>
    public const string FLIGHT_MODE_JSON = "FLIGHT_MODE_JSON";
}