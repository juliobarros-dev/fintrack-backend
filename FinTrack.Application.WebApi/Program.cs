using Asp.Versioning;
using FinTrack.Application.WebApi.Extensions;
using FinTrack.Infrastructure.Database.Extensions;

var builder = WebApplication.CreateBuilder(args);

var basePath = typeof(Program).Assembly.GetDirectoryName();

builder.Configuration
	.SetBasePath(basePath)
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
	.AddJsonFile("appsettings.database.json", optional: true, reloadOnChange: true)
	.AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddApiVersioning(options =>
{
	options.ReportApiVersions = true;
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddApplicationContext(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
