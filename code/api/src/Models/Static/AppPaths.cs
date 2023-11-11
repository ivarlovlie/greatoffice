
namespace IOL.GreatOffice.Api.Models.Static;

public static class AppPaths
{
	public static AppPath AppData => new()
	{
		HostPath = Path.Combine(Directory.GetCurrentDirectory(), "AppData")
	};

	public static AppPath DataProtectionKeys => new()
	{
		HostPath = Path.Combine(Directory.GetCurrentDirectory(), "AppData", "dp-keys")
	};

	public static AppPath Frontend => new()
	{
		HostPath = Path.Combine(Directory.GetCurrentDirectory(), "Frontend")
	};
}
