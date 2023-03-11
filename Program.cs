var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/validate", (string phoneNumber) =>
{
	return phoneNumber;
});

app.Run();
