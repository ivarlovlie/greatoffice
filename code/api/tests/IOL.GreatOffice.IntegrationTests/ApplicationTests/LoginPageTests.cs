using IOL.GreatOffice.IntegrationTests.Helpers;
using Xunit;

namespace IOL.GreatOffice.IntegrationTests.ApplicationTests;

public class LoginPageTests : IClassFixture<WebServerFixture>
{
	private readonly WebServerFixture _fixture;

	public LoginPageTests(WebServerFixture fixture)
	{
		_fixture = fixture;
	}

	[Fact]
	public async Task LoginPageTestsRenders()
	{
		var page = await _fixture.Browser.NewPageAsync();
		await page.GotoAsync(_fixture.BaseUrl);

		var actual = await page.TextContentAsync(Element.ByName("Page Title"));

		Assert.Equal("Welcome", actual);
	}
}
