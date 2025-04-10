using FinTrack.CrossCutting.Extensions;
using FinTrack.Infrastructure.Database.Implementations.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FinTrack.Infrastructure.Database.Factory;

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
	public ApplicationContext CreateDbContext(string[] args)
	{
		var path = typeof(ApplicationContextFactory).Assembly.GetDirectoryName();

		var config = new ConfigurationBuilder()
			.SetBasePath(path)
			.AddJsonFile("appsettings.database.json", optional: false)
			.Build();

		var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
		optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

		return new ApplicationContext(optionsBuilder.Options);
	}
}
