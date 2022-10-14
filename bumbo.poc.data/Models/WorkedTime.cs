namespace bumbo.poc.data.Models;

public sealed class WorkedTime
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime OverwriteStartTime { get; set; }
    public DateTime OverwriteEndTime { get; set; }
    public DateTime ApprovedAt { get; set; }
    public DateTime SendAt { get; set; }
}