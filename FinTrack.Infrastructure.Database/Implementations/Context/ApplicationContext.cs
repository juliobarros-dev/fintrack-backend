using FinTrack.Infrastructure.Database.Interfaces;
using FinTrack.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTrack.Infrastructure.Database.Implementations.Context;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options), IApplicationContext
{
	public DbSet<Bank> Banks { get; set; }
	public DbSet<Card> Cards { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Expense> Expenses { get; set; }
	public DbSet<Income> Incomes { get; set; }
	public DbSet<Installment> Installments { get; set; }
	public DbSet<PaymentMethod> PaymentMethods { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("core");

		base.OnModelCreating(modelBuilder);
	}
}