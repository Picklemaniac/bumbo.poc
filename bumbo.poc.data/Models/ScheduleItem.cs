namespace bumbo.poc.data.Models;

public sealed class ScheduleItem
{
    public int Id { get; set; }
    public string DepartmentName { get; set; }
    public int UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int BranchId { get; set; }
    public DateTime ArchivedAt { get; set; }
    public DateTime PublishedAt { get; set; }
}