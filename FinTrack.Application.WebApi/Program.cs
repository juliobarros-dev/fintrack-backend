using Asp.Versioning;
using FinTrack.Application.WebApi.Extensions;
using FinTrack.Infrastructure.Database.Extensions;
using FinTrack.Infrastructure.Database.Implementations.Context;
using FinTrack.Infrastructure.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var basePath = typeof(Program).Assembly.GetDirectoryName();

builder.Configuration
	.SetBasePath(basePath)
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
	.AddJsonFile("appsettings.database.json", optional: true, reloadOnChange: true)
	.AddEnvironmentVariables();

builder.Services
	.AddApplicationContext(builder.Configuration)
	.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddApiVersioning(options =>
{
	options.ReportApiVersions = true;
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.DefaultApiVersion = new ApiVersion(1, 0);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
	context.Database.Migrate();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UsePathBase("/fintrack");

app.Run();
