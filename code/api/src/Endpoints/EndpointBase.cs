using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace IOL.GreatOffice.Api.Endpoints;

[ApiController]
public class EndpointBase : ControllerBase
{
    /// <summary>
    /// User data for the currently logged on user.
    /// </summary>
    protected LoggedInUserModel LoggedInUser => new()
    {
        Username = User.FindFirstValue(AppClaims.NAME),
        Id = User.FindFirstValue(AppClaims.USER_ID).AsGuid(),
    };

    [NonAction]
    protected ActionResult KnownProblem(string title = default, string subtitle = default, Dictionary<string, string[]> errors = default)
    {
        HttpContext.Response.Headers.Append(AppHeaders.IS_KNOWN_PROBLEM, "1");
        return BadRequest(new KnownProblemModel
        {
            Title = title,
            Subtitle = subtitle,
            Errors = errors,
            TraceId = HttpContext.TraceIdentifier
        });
    }

    [NonAction]
    protected ActionResult KnownProblem(KnownProblemModel problem)
    {
        HttpContext.Response.Headers.Append(AppHeaders.IS_KNOWN_PROBLEM, "1");
        problem.TraceId = HttpContext.TraceIdentifier;
        return BadRequest(problem);
    }

    [NonAction]
    protected RequestTimeZoneInfo GetRequestTimeZone(ILogger logger = default)
    {
        Request.Headers.TryGetValue(AppHeaders.BROWSER_TIME_ZONE, out var timeZoneHeader);
        var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneHeader.ToString().HasValue() ? timeZoneHeader.ToString() : "UTC");
        var offset = tz.BaseUtcOffset.Hours;

        // This is fine as long as the client is not connecting from Australia: Lord Howe Island,
        // according to https://en.wikipedia.org/wiki/Daylight_saving_time_by_country
        if (tz.IsDaylightSavingTime(AppDateTime.UtcNow))
        {
            offset++;
        }

        logger?.LogInformation("Request time zone (" + tz.Id + ") offset is: " + offset + " hours");

        return new RequestTimeZoneInfo()
        {
            TimeZoneInfo = tz,
            Offset = offset,
            LocalDateTime = TimeZoneInfo.ConvertTimeFromUtc(AppDateTime.UtcNow, tz)
        };
    }
}