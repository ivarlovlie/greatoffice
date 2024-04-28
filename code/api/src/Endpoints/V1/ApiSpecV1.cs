namespace IOL.GreatOffice.Api.Endpoints.V1;

public static class ApiSpecV1
{
    private const int MAJOR = 1;
    private const int MINOR = 0;
    public const string VERSION_STRING = "1.0";

    public static ApiSpecDocument Document => new() {
        Version = new ApiVersion(MAJOR, MINOR),
        VersionName = VERSION_STRING,
        SwaggerPath = $"/swagger/{VERSION_STRING}/swagger.json",
        OpenApiInfo = new OpenApiInfo {
            Title = AppConstants.API_NAME,
            Version = VERSION_STRING
        }
    };
}