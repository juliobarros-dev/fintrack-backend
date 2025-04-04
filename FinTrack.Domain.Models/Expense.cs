namespace FinTrack.Domain.Models;

public class Expense
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public decimal Amount { get; set; }
	public bool IsInstallment  { get; set; }
	public int? InstallmentCount { get; set; }
	public PaymentMethod PaymentMethod { get; set; } = new();
	public Bank Bank { get; set; } = new();
	public Card? Card { get; set; } = new();
	public Category Category { get; set; } = new();
	public List<Installment> Installments { get; set; } = [];
	public DateTime Date { get; set; }
}