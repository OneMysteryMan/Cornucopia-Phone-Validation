using Cornucopia_Phone_Validation;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/regions", () => RegionMap.Json);
app.MapGet("/api/validate", NumberValidator.Parse);

app.Run();
