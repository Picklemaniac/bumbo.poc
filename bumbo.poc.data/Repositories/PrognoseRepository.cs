using bumbo.poc.data.Extensions;
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
        var firstDayOfCurrentWeek = DateOnly.FromDateTime(DateTime.Now).GetFirstDayOfWeekByDate();

        return _database.PrognosisInputs.Where(i =>
            i.Date >= firstDayOfCurrentWeek && i.Date < firstDayOfCurrentWeek.GetLastDayOfWeekByDate());
    }

    public IEnumerable<Prognosis> GetPrognosesForCurrentWeek()
    {
        return GetPrognosesByWeek(DateOnly.FromDateTime(DateTime.Now));
    }

    public IEnumerable<Prognosis> GetPrognosesByWeek(DateOnly dayInWeek)
    {
        var firstDayOfCurrentWeek = dayInWeek.GetFirstDayOfWeekByDate();
        return _database.Prognoses.Where(p => p.Date >= firstDayOfCurrentWeek && p.Date < firstDayOfCurrentWeek.AddDays(7));
    }

    private Prognosis? GetPrognosisByDate(DateOnly dateOnly)
{
        return _database.Prognoses.FirstOrDefault(p => p.Date == dateOnly);
    }

    public double PrognosisCoveredByDayPercentage(DateOnly dateOnly)
    {
        return decimal.ToDouble(GetPrognosisByDate(dateOnly).WorkHours) / _scheduleItemsRepository.GetPlannedWorkHoursByDate(dateOnly)*100;
    }

    public double PrognosisCoveredByWeekPercentage(DateOnly dateOnly)
    {
        return decimal.ToDouble(GetPrognosesByWeek(dateOnly).Sum(p => p.WorkHours)) / _scheduleItemsRepository.GetPlannedWorkHoursByWeek(dateOnly)*100;
    }
}