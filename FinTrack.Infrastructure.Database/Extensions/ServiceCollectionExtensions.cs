using FinTrack.Infrastructure.Database.Context;
using FinTrack.Infrastructure.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinTrack.Infrastructure.Database.Extensions;

public static class ServiceCollectionExtensions
{
	private static string? _connectionString = "";
	
	public static IServiceCollection AddApplicationContext(this IServiceCollection serviceCollection, IConfiguration configuration)
	{
		_connectionString = configuration.GetConnectionString("DefaultConnection");

		serviceCollection
			.AddIncomeContext()
			.AddExpenseContext()
			.AddScoped<IIncomeDbContext, IncomeDbContext>()
			.AddScoped<IExpenseDbContext, ExpenseDbContext>();

		return serviceCollection;
	}
	
	private static IServiceCollection AddIncomeContext(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddDbContext<IncomeDbContext>(options =>
		{
			options.UseNpgsql(_connectionString);
		});

		return serviceCollection;
	}
	
	private static IServiceCollection AddExpenseContext(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddDbContext<ExpenseDbContext>(options =>
		{
			options.UseNpgsql(_connectionString);
		});

		return serviceCollection;
	}
}