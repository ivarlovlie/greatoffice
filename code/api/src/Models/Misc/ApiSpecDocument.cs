namespace IOL.GreatOffice.Api.Models.Misc;

public class ApiSpecDocument
{
	public string VersionName { get; set; }
	public string SwaggerPath { get; set; }
	public ApiVersion Version { get; set; }
	public OpenApiInfo OpenApiInfo { get; set; }
}
