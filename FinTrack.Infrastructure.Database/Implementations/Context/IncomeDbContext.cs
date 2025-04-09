using FinTrack.Infrastructure.Database.Interfaces;
using FinTrack.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTrack.Infrastructure.Database.Implementations.Context;

public class IncomeDbContext(DbContextOptions<IncomeDbContext> options) : DbContext(options), IIncomeDbContext
{
	public DbSet<Income> Incomes { get; set; }
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("income");
		
		base.OnModelCreating(modelBuilder);
	}
}