namespace IOL.GreatOffice.Api.Models.Static;

public static class JsonSettings
{
	public static Action<JsonOptions> SetDefaultAction { get; } = options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
		options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
		options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
	};
	public static readonly JsonSerializerOptions WriteIndented = new()
	{
		WriteIndented = true
	};
}
