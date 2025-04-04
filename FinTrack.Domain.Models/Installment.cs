namespace FinTrack.Domain.Models;

public class Installment
{
	public int Id { get; set; }
	public int ExpenseIde { get; set; }
	public int InstallmentNumber { get; set; }
	public decimal Amount { get; set; }
	public DateTime DueDate { get; set; }
	public bool IsPaid { get; set; }
}