using bumbo.poc.data.Extensions;
using bumbo.poc.data.Models;

namespace bumbo.poc.data.Repositories;

public sealed class ScheduleItemsRepository
{
    private readonly Database _database;

    public ScheduleItemsRepository(Database database)
    {
        _database = database;
    }

    public double GetPlannedWorkHoursByDate(DateOnly dateOnly)
    {
        return _database.ScheduleItems.Where(s => DateOnly.FromDateTime(s.StartTime) == dateOnly)
            .Sum(s => (s.EndTime.Subtract(s.StartTime).TotalHours));
    }

    public double GetPlannedWorkHoursByWeek(DateOnly dateOnly)
    {
        var firstDayOfCurrentWeek = dateOnly.GetFirstDayOfWeekByDate();
        return _database.ScheduleItems.Where(s => DateOnly.FromDateTime(s.StartTime.Date) >= firstDayOfCurrentWeek && DateOnly.FromDateTime(s.StartTime.Date) < firstDayOfCurrentWeek.GetLastDayOfWeekByDate())
            .Sum(s => (s.EndTime.Subtract(s.StartTime).TotalHours));
    }

    public IEnumerable<ScheduleItem> GetScheduleItems()
    {
        return _database.ScheduleItems;
    }
}