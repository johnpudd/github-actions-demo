using FastEndpoints;

public class MyEndpoint : Endpoint<MyRequest, MyResponse>
{
    public override void Configure()
    {
        var path = "/api/user/create";
        Get(path);
        Post(path);
        AllowAnonymous();
    }

    public override async Task HandleAsync(MyRequest req, CancellationToken ct)
    {
        var name = string.Join(" ", new[] { req.FirstName, req.LastName }.Where(s => !string.IsNullOrEmpty(s)));
        await Send.OkAsync(new()
        {
            FullName = name,
            IsOver18 = req.Age >= 18
        });
    }
}
