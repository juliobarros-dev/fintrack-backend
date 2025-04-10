using FinTrack.Infrastructure.Database.Implementations.Context;
using FinTrack.Infrastructure.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinTrack.Infrastructure.Database.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddApplicationContext(this IServiceCollection serviceCollection, IConfiguration configuration)
	{
		serviceCollection
			.AddDbContext<ApplicationContext>(options =>
				options.UseNpgsql(
						configuration.GetConnectionString("DefaultConnection"),
						o => o.MigrationsHistoryTable("__EFMigrationsHistory", "core"))
					.EnableSensitiveDataLogging()
					.LogTo(Console.WriteLine)
			);
		
		serviceCollection.AddScoped<IApplicationContext, ApplicationContext>();

		return serviceCollection;
	}
}