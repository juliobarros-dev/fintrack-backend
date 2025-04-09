using FinTrack.Infrastructure.Database.Interfaces;
using FinTrack.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTrack.Infrastructure.Database.Context;

public class ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : DbContext(options), IExpenseDbContext
{
	public DbSet<Expense> Expenses { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("expense");

		base.OnModelCreating(modelBuilder);
	}
}