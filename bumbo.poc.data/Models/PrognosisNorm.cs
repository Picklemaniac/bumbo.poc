namespace bumbo.poc.data.Models;

public sealed class PrognosisNorm
{
    public int Id { get; set; }
    public decimal TimeUnloadPackages { get; set; }
    public decimal TimeStockingShelves { get; set; }
    public decimal ClientsPerMinute { get; set; }
    // fresh_department ? See ERD.
    public decimal ShelvesPerMinute { get; set; }
    public DateTime CreatedAt { get; set; }
    public int BranchId { get; set; }
}