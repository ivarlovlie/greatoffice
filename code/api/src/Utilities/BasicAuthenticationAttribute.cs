using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IOL.GreatOffice.Api.Utilities;

public class BasicAuthenticationAttribute : TypeFilterAttribute
{
	public BasicAuthenticationAttribute(string claimPermission) : base(typeof(BasicAuthenticationFilter))
	{
		Arguments = [
				new Claim(claimPermission, "True")
		];
	}
}

public class BasicAuthenticationFilter : IAuthorizationFilter
{
	private readonly Claim _claim;

	public BasicAuthenticationFilter(Claim claim)
	{
		_claim = claim;
	}

	public void OnAuthorization(AuthorizationFilterContext context)
	{
		if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues authzHeaderValue)) return;
		try
		{
			var authHeader = AuthenticationHeaderValue.Parse(authzHeaderValue);
			if (authHeader.Parameter is null)
			{
				context.Result = new ForbidResult(AppConstants.BASIC_AUTH_SCHEME);
			}

			var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
			if (!hasClaim)
			{
				context.Result = new ForbidResult(AppConstants.BASIC_AUTH_SCHEME);
			}
		}
		catch
		{
			// ignore
		}
	}
}
