namespace IOL.GreatOffice.Api.Data.Models;

public sealed record AppPath
{
	public string HostPath { get; init; }
	public string WebPath { get; init; }

	public string GetHostPathForFilename(string filename, string fallback = "") {
		if (filename.IsNullOrWhiteSpace()) {
			return fallback;
		}

		return Path.Combine(HostPath, filename);
	}

	public string GetWebPathForFilename(string filename, string fallback = "") {
		if (filename.IsNullOrWhiteSpace()) {
			return fallback;
		}

		return Path.Combine(WebPath, filename);
	}
}
