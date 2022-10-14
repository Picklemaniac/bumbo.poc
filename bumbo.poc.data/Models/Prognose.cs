namespace bumbo.poc.data.Models;

public sealed class Prognose
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public int BranchId { get; set; }
    public int DepartmentId { get; set; }
    public decimal WorkHours { get; set; }
    public DateTime CreatedAt { get; set; }

}