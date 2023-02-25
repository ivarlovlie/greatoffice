using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.Playwright;
using Xunit;
using Program = IOL.GreatOffice.Api.Program;

namespace IOL.GreatOffice.IntegrationTests.Helpers;

// ReSharper disable once ClassNeverInstantiated.Global
public class WebServerFixture : IAsyncLifetime, IDisposable
{
	private readonly WebApplication Host;
	private IPlaywright Playwright { get; set; }
	public IBrowser Browser { get; private set; }
	public string BaseUrl { get; } = $"https://localhost:{GetRandomUnusedPort()}";

	public WebServerFixture() {
		Host = Program.CreateWebApplication(Program.CreateAppBuilder(default));
	}

	public async Task InitializeAsync() {
		Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
		Browser = await Playwright.Chromium.LaunchAsync();
		await Host.StartAsync();
	}

	public async Task DisposeAsync() {
		await Host.StopAsync();
		await Host.DisposeAsync();
		Playwright?.Dispose();
	}

	public void Dispose() {
		Host.StopAsync();
		Host.DisposeAsync();
		Playwright?.Dispose();
		GC.SuppressFinalize(this);
	}

	private static int GetRandomUnusedPort() {
		var listener = new TcpListener(IPAddress.Any, 0);
		listener.Start();
		var port = ((IPEndPoint)listener.LocalEndpoint).Port;
		listener.Stop();
		return port;
	}
}
