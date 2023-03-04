using Microsoft.Extensions.Caching.Memory;

namespace IOL.GreatOffice.Api.Services;

public class VaultService
{
    private readonly HttpClient _client;
    private readonly IMemoryCache _cache;
    private readonly IConfiguration _configuration;
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
        if (_configuration.GetValue<bool>(AppEnvironmentVariables.FLIGHT_MODE)) {
            var text = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetValue(AppEnvironmentVariables.FLIGHT_MODE_JSON, "flightmode.json")));
            return JsonSerializer.Deserialize<AppConfiguration>(text);
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