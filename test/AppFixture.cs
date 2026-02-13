using Microsoft.AspNetCore.Mvc.Testing;

namespace github_actions_demo_app.Tests;

public class AppFixture : WebApplicationFactory<Program>
{
    public HttpClient Client => CreateClient();
}
