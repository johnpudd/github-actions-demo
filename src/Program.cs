using FastEndpoints;

var bld = WebApplication.CreateBuilder(args);
bld.Services.AddFastEndpoints();

var app = bld.Build();
app.UseFastEndpoints();
app.Run();

public partial class Program { }