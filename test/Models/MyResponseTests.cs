using Xunit;

namespace github_actions_demo_app.Tests.Models;

public class MyResponseTests
{
    [Fact]
    public void MyResponse_DefaultValues_ShouldBeInitialized()
    {
        var response = new MyResponse();

        Assert.Equal("", response.FullName);
        Assert.False(response.IsOver18);
    }

    [Fact]
    public void MyResponse_SetProperties_ShouldReturnSetValues()
    {
        var response = new MyResponse
        {
            FullName = "John Doe",
            IsOver18 = true
        };

        Assert.Equal("John Doe", response.FullName);
        Assert.True(response.IsOver18);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("Jane Smith", true)]
    [InlineData("Minor Person", false)]
    [InlineData("Adult Person", true)]
    public void MyResponse_VariousValues_ShouldBeSet(string fullName, bool isOver18)
    {
        var response = new MyResponse
        {
            FullName = fullName,
            IsOver18 = isOver18
        };

        Assert.Equal(fullName, response.FullName);
        Assert.Equal(isOver18, response.IsOver18);
    }
}
