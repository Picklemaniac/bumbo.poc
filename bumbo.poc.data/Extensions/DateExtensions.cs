namespace bumbo.poc.data.Extensions;

public static class DateExtensions
{
    public static DateOnly GetFirstDayOfWeekByDate(this DateOnly date)
    {
        while (date.DayOfWeek != DayOfWeek.Sunday)
        {
            date = date.AddDays(-1);
        }
        return date;
    }

    public static DateOnly GetLastDayOfWeekByDate(this DateOnly date)
    {
        while (date.DayOfWeek != DayOfWeek.Saturday)
        {
            date = date.AddDays(1);
        }
        return date;
    }
}