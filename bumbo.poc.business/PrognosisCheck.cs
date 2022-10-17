using System.Collections;
using bumbo.poc.data.Models;
using bumbo.poc.data.Repositories;

namespace bumbo.poc.business;

public sealed class PrognosisCheck
{
    private readonly ScheduleItemsRepository _scheduleItemsRepository;
    private readonly PrognosisRepository _prognosisRepository;

    public PrognosisCheck(ScheduleItemsRepository scheduleItemsRepository, PrognosisRepository prognosisRepository)
    {
        _scheduleItemsRepository = scheduleItemsRepository;
        _prognosisRepository = prognosisRepository;
    }

    public ArrayList HoursPrognosisNotCovered(DateOnly dateOnly)
    {
        var scheduleItems = _scheduleItemsRepository.GetScheduleItems()
            .Where(s => DateOnly.FromDateTime(s.StartTime).Day == dateOnly.Day).ToList();

        var hoursNotCovered = new ArrayList();
        for (var i = OpeningTimes.OPENINGTIME; i <= OpeningTimes.CLOSINGTIME; i.AddHours(1))
        {
            if (scheduleItems.Find(s => TimeOnly.FromDateTime(s.StartTime) <= i && TimeOnly.FromDateTime(s.EndTime) >= i) is null)
            {
                hoursNotCovered.Add(i);
            }
        }
        return hoursNotCovered;
    }

    public bool IsPrognosisCoveredByDay(DateOnly dateOnly)
    {
        return _prognosisRepository.PrognosisCoveredByDayPercentage(dateOnly) >= 100;
    }
}