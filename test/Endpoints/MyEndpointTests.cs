using System.Net.Http.Json;
using Xunit;

namespace github_actions_demo_app.Tests.Endpoints;

public class MyEndpointTests : IClassFixture<AppFixture>
{
    private readonly HttpClient _client;

    public MyEndpointTests(AppFixture fixture)
    {
        _client = fixture.Client;
    }

    [Fact]
    public async Task HandleAsync_WithFullName_ReturnsCorrectFullName()
    {
        var request = new MyRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Age = 25
        };

        var response = await _client.PostAsJsonAsync("/api/user/create", request);
        response.EnsureSuccessStatusCode();
        
        var result = await response.Content.ReadFromJsonAsync<MyResponse>();

        Assert.NotNull(result);
        Assert.Equal("John Doe", result.FullName);
        Assert.True(result.IsOver18);
    }

    [Fact]
    public async Task HandleAsync_WithFirstNameOnly_ReturnsFirstName()
    {
        var request = new MyRequest
        {
            FirstName = "Jane",
            LastName = "",
            Age = 30
        };

        var response = await _client.PostAsJsonAsync("/api/user/create", request);
        response.EnsureSuccessStatusCode();
        
        var result = await response.Content.ReadFromJsonAsync<MyResponse>();

        Assert.NotNull(result);
        Assert.Equal("Jane", result.FullName);
        Assert.True(result.IsOver18);
    }

    [Fact]
    public async Task HandleAsync_WithLastNameOnly_ReturnsLastName()
    {
        var request = new MyRequest
        {
            FirstName = "",
            LastName = "Smith",
            Age = 20
        };

        var response = await _client.PostAsJsonAsync("/api/user/create", request);
        response.EnsureSuccessStatusCode();
        
        var result = await response.Content.ReadFromJsonAsync<MyResponse>();

        Assert.NotNull(result);
        Assert.Equal("Smith", result.FullName);
        Assert.True(result.IsOver18);
    }

    [Fact]
    public async Task HandleAsync_WithAgeUnder18_ReturnsFalseForIsOver18()
    {
        var request = new MyRequest
        {
            FirstName = "Minor",
            LastName = "Person",
            Age = 17
        };

        var response = await _client.PostAsJsonAsync("/api/user/create", request);
        response.EnsureSuccessStatusCode();
        
        var result = await response.Content.ReadFromJsonAsync<MyResponse>();

        Assert.NotNull(result);
        Assert.Equal("Minor Person", result.FullName);
        Assert.False(result.IsOver18);
    }

    [Fact]
    public async Task HandleAsync_WithAge18_ReturnsTrueForIsOver18()
    {
        var request = new MyRequest
        {
            FirstName = "Adult",
            LastName = "Person",
            Age = 18
        };

        var response = await _client.PostAsJsonAsync("/api/user/create", request);
        response.EnsureSuccessStatusCode();
        
        var result = await response.Content.ReadFromJsonAsync<MyResponse>();

        Assert.NotNull(result);
        Assert.Equal("Adult Person", result.FullName);
        Assert.True(result.IsOver18);
    }

    [Fact]
    public async Task HandleAsync_WithEmptyNames_ReturnsEmptyString()
    {
        var request = new MyRequest
        {
            FirstName = "",
            LastName = "",
            Age = 25
        };

        var response = await _client.PostAsJsonAsync("/api/user/create", request);
        response.EnsureSuccessStatusCode();
        
        var result = await response.Content.ReadFromJsonAsync<MyResponse>();

        Assert.NotNull(result);
        Assert.Equal("", result.FullName);
        Assert.True(result.IsOver18);
    }

    [Fact]
    public async Task HandleAsync_WithNullNames_ReturnsEmptyString()
    {
        var request = new MyRequest
        {
            FirstName = null!,
            LastName = null!,
            Age = 25
        };

        var response = await _client.PostAsJsonAsync("/api/user/create", request);
        response.EnsureSuccessStatusCode();
        
        var result = await response.Content.ReadFromJsonAsync<MyResponse>();

        Assert.NotNull(result);
        Assert.Equal("", result.FullName);
        Assert.True(result.IsOver18);
    }
}
