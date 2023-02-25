namespace IOL.GreatOffice.Api.Data.Static;

public static class JsonSettings
{
	public static Action<JsonOptions> Default { get; } = options => {
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
		options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
		options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
	};
}
