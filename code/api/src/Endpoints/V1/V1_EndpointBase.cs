using System.Net.Http.Headers;

namespace IOL.GreatOffice.Api.Endpoints.V1;

[ApiVersion(ApiSpecV1.VERSION_STRING)]
[Authorize(AuthenticationSchemes = AuthSchemes)]
public class V1_EndpointBase : EndpointBase
{
    private const string AuthSchemes = CookieAuthenticationDefaults.AuthenticationScheme + "," + AppConstants.BASIC_AUTH_SCHEME;

    protected bool IsApiCall() {
        if (!Request.Headers.TryGetValue("Authorization", out var value)) return false;
        try {
            var authHeader = AuthenticationHeaderValue.Parse(value);
            if (authHeader.Parameter == null) return false;
        } catch {
            return false;
        }

        return true;
    }

    protected bool HasApiPermission(string permission_key) {
        var permission_claim = User.Claims.FirstOrDefault(c => c.Type == permission_key);
        return permission_claim is {
            Value: "True"
        };
    }
}