namespace github_actions_demo_app.Tests.Models;

public class MyRequestTests
{
    [Fact]
    public void MyRequest_DefaultValues_ShouldBeInitialized()
    {
        var request = new MyRequest();

        Assert.Equal("", request.FirstName);
        Assert.Equal("", request.LastName);
        Assert.Equal(0, request.Age);
    }

    [Fact]
    public void MyRequest_SetProperties_ShouldReturnSetValues()
    {
        var request = new MyRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Age = 25
        };

        Assert.Equal("John", request.FirstName);
        Assert.Equal("Doe", request.LastName);
        Assert.Equal(25, request.Age);
    }

    [Theory]
    [InlineData("", "", 0)]
    [InlineData("Jane", "Smith", 30)]
    [InlineData("Bob", "", 45)]
    [InlineData("", "Johnson", 18)]
    public void MyRequest_VariousValues_ShouldBeSet(string firstName, string lastName, int age)
    {
        var request = new MyRequest
        {
            FirstName = firstName,
            LastName = lastName,
            Age = age
        };

        Assert.Equal(firstName, request.FirstName);
        Assert.Equal(lastName, request.LastName);
        Assert.Equal(age, request.Age);
    }
}
