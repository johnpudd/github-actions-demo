using Microsoft.AspNetCore.Mvc.Testing;

namespace github_actions_demo_app.Tests;

public class AppFixture : WebApplicationFactory<Program>
{
    private readonly HttpClient _client;
    public AppFixture()
    {
        _client = CreateClient();
    }
    public HttpClient Client => _client;
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _client.Dispose();
        }
        base.Dispose(disposing);
    }
}
