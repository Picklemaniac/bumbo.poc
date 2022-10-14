using bumbo.poc.data.Models;

namespace bumbo.poc.data.Repositories;

public sealed class PrognosisRepository
{
    private readonly Database _database;
    private readonly ScheduleItemsRepository _scheduleItemsRepository;

    public PrognosisRepository(Database database, ScheduleItemsRepository scheduleItemsRepository)
    {
        _database = database;
        _scheduleItemsRepository = scheduleItemsRepository;
    }

    public IEnumerable<PrognosisInput> GetPrognosisInputsForCurrentWeek()
    {
        var firstDayOfCurrentWeek = GetFirstDayOfWeekByDate(DateOnly.FromDateTime(DateTime.Now));

        return _database.PrognosisInputs.Where(i =>
            i.Date >= firstDayOfCurrentWeek && i.Date < firstDayOfCurrentWeek.AddDays(7));
    }

    public IEnumerable<Prognosis> GetPrognosesForCurrentWeek()
    {
        var firstDayOfCurrentWeek = GetFirstDayOfWeekByDate(DateOnly.FromDateTime(DateTime.Now));
        return _database.Prognoses.Where(p => p.Date >= firstDayOfCurrentWeek && p.Date < firstDayOfCurrentWeek.AddDays(7));
    }

    private Prognosis? GetPrognosisByDate(DateOnly dateOnly)
    {
        return _database.Prognoses.FirstOrDefault(p => p.Date == dateOnly);
    }

    private static DateOnly GetFirstDayOfWeekByDate(DateOnly date)
    {
        while (date.DayOfWeek != DayOfWeek.Sunday)
        {
            date = date.AddDays(-1);
        }
        return date;
    }

    public double PrognosisCoveredByDayPercentage(DateOnly dateOnly)
    {
        return decimal.ToDouble(GetPrognosisByDate(dateOnly).WorkHours) / _scheduleItemsRepository.GetPlannedWorkHoursByDate(dateOnly)*100;
    }
}