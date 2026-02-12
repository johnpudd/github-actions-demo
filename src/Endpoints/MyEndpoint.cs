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
        await Send.OkAsync(new()
        {
            FullName = req.FirstName + (req.FirstName =="" ||  req.LastName == "") ? " " : "" + req.LastName
            IsOver18 = req.Age >= 18
        });
    }
}
