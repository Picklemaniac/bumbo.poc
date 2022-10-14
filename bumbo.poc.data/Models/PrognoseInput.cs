namespace bumbo.poc.data.Models;

public sealed class PrognosisInput
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public int ExpectedPackages { get; set; }
    public int ExpectedCustomers { get; set; }
    public int BranchId { get; set; }
}