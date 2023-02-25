using Microsoft.Extensions.Caching.Memory;

namespace IOL.GreatOffice.Api.Services;

public class VaultService
{
    private readonly HttpClient _client;
    private readonly IMemoryCache _cache;
    private readonly IConfiguration _configuration;
    private readonly ILogger<VaultService> _logger;
    private int CACHE_TTL { get; set; }

    public VaultService(HttpClient client, IConfiguration configuration, IMemoryCache cache, ILogger<VaultService> logger) {
        var token = configuration.GetValue<string>(AppEnvironmentVariables.VAULT_TOKEN);
        var vaultUrl = configuration.GetValue<string>(AppEnvironmentVariables.VAULT_URL);
        CACHE_TTL = configuration.GetValue(AppEnvironmentVariables.VAULT_CACHE_TTL, 60 * 60 * 12);
        if (token.IsNullOrWhiteSpace()) throw new ApplicationException("VAULT_TOKEN is empty");
        if (vaultUrl.IsNullOrWhiteSpace()) throw new ApplicationException("VAULT_URL is empty");
        client.DefaultRequestHeaders.Add("X-Vault-Token", token);
        client.BaseAddress = new Uri(vaultUrl);
        _client = client;
        _cache = cache;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<T> GetSecretJsonAsync<T>(string path) {
        var result = await _cache.GetOrCreate(AppConstants.VAULT_CACHE_KEY,
            async cacheEntry => {
                cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(CACHE_TTL);
                var getSecretResponse = await _client.GetFromJsonAsync<GetSecretResponse<T>>("/v1/kv/data/" + path);
                if (getSecretResponse == null) {
                    return default;
                }

                Log.Debug("Setting new vault cache, " + new {
                    PATH = path,
                    CACHE_TTL,
                    Data = JsonSerializer.Serialize(getSecretResponse.Data.Data)
                });
                return getSecretResponse.Data.Data ?? default;
            });
        return result;
    }

    public Task<T> RefreshAsync<T>(string path) {
        _cache.Remove(AppConstants.VAULT_CACHE_KEY);
        CACHE_TTL = _configuration.GetValue(AppEnvironmentVariables.VAULT_CACHE_TTL, 60 * 60 * 12);
        return GetSecretJsonAsync<T>(path);
    }

    public async Task<RenewTokenResponse> RenewTokenAsync() {
        var response = await _client.PostAsJsonAsync("v1/auth/token/renew-self", new {increment = "2h"});
        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadFromJsonAsync<RenewTokenResponse>();
        }

        return default;
    }

    public async Task<TokenLookupResponse> LookupTokenAsync() {
        var response = await _client.GetAsync("v1/auth/token/lookup-self");
        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadFromJsonAsync<TokenLookupResponse>();
        }

        return default;
    }

    public AppConfiguration GetCurrentAppConfiguration() {
#if DEBUG
        var isInFlightMode = true;
        if (isInFlightMode) {
            return new AppConfiguration() {
                EMAIL_FROM_ADDRESS = "heydev@greatoffice.life",
                DB_HOST = "localhost",
                DB_PORT = "5432",
                DB_NAME = "greatoffice_ivar_dev",
                DB_PASSWORD = "ivar123",
                DB_USER = "postgres",
                CANONICAL_FRONTEND_URL = "http://localhost:5173",
                CANONICAL_BACKEND_URL = "http://localhost:5000",
                POSTMARK_TOKEN = "b530c311-45c7-43e5-aa48-f2c992886e51",
                QUARTZ_DB_HOST = "localhost",
                QUARTZ_DB_PORT = "5432",
                QUARTZ_DB_NAME = "greatoffice_quartz_ivar_dev",
                QUARTZ_DB_PASSWORD = "ivar123",
                QUARTZ_DB_USER = "postgres",
                APP_CERT = "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"
            };
        }
#endif

        return GetSecretJsonAsync<AppConfiguration>(
            _configuration.GetValue<string>(AppEnvironmentVariables.MAIN_CONFIG_SHEET)
        ).Result;
    }

    public async Task RefreshCurrentAppConfigurationAsync() {
        await RefreshAsync<AppConfiguration>(_configuration.GetValue<string>(AppEnvironmentVariables.MAIN_CONFIG_SHEET));
    }

    public class RenewTokenResponse
    {
        public Guid RequestId { get; set; }
        public string LeaseId { get; set; }
        public bool Renewable { get; set; }
        public long LeaseDuration { get; set; }
        public object Data { get; set; }
        public object WrapInfo { get; set; }
        public List<string> Warnings { get; set; }
        public Auth Auth { get; set; }
    }

    public class Auth
    {
        public string ClientToken { get; set; }
        public string Accessor { get; set; }
        public List<string> Policies { get; set; }
        public List<string> TokenPolicies { get; set; }
        public object Metadata { get; set; }
        public long LeaseDuration { get; set; }
        public bool Renewable { get; set; }
        public string EntityId { get; set; }
        public string TokenType { get; set; }
        public bool Orphan { get; set; }
        public object MfaRequirement { get; set; }
        public long NumUses { get; set; }
    }

    public class GetSecretResponse<T>
    {
        public VaultSecret<T> Data { get; set; }
    }

    public class VaultSecret<T>
    {
        public T Data { get; set; }
        public VaultSecretMetadata Metadata { get; set; }
    }

    public class VaultSecretMetadata
    {
        public DateTimeOffset CreatedTime { get; set; }
        public object CustomMetadata { get; set; }
        public string DeletionTime { get; set; }
        public bool Destroyed { get; set; }
        public long Version { get; set; }
    }

    public class TokenLookupResponse
    {
        [JsonPropertyName("request_id")]
        public Guid RequestId { get; set; }

        [JsonPropertyName("lease_id")]
        public string LeaseId { get; set; }

        [JsonPropertyName("renewable")]
        public bool Renewable { get; set; }

        [JsonPropertyName("lease_duration")]
        public long LeaseDuration { get; set; }

        [JsonPropertyName("data")]
        public TokenLookupResponseData Data { get; set; }

        [JsonPropertyName("wrap_info")]
        public object WrapInfo { get; set; }

        [JsonPropertyName("warnings")]
        public object Warnings { get; set; }

        [JsonPropertyName("auth")]
        public object Auth { get; set; }
    }

    public class TokenLookupResponseData
    {
        [JsonPropertyName("accessor")]
        public string Accessor { get; set; }

        [JsonPropertyName("creation_time")]
        public long CreationTime { get; set; }

        [JsonPropertyName("creation_ttl")]
        public long CreationTtl { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("entity_id")]
        public string EntityId { get; set; }

        [JsonPropertyName("expire_time")]
        public DateTimeOffset ExpireTime { get; set; }

        [JsonPropertyName("explicit_max_ttl")]
        public long ExplicitMaxTtl { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("issue_time")]
        public DateTimeOffset IssueTime { get; set; }

        [JsonPropertyName("last_renewal")]
        public DateTimeOffset LastRenewal { get; set; }

        [JsonPropertyName("last_renewal_time")]
        public long LastRenewalTime { get; set; }

        [JsonPropertyName("meta")]
        public object Meta { get; set; }

        [JsonPropertyName("num_uses")]
        public long NumUses { get; set; }

        [JsonPropertyName("orphan")]
        public bool Orphan { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("policies")]
        public List<string> Policies { get; set; }

        [JsonPropertyName("renewable")]
        public bool Renewable { get; set; }

        [JsonPropertyName("ttl")]
        public long Ttl { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}