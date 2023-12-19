using Bujit.Core.Enums;

namespace Bujit.Core.Transactions;

public abstract record TransactionInstance(TransactionFrequencyType Frequency, TransactionType TransactionType, decimal Amount, DateTime StartDate, DateTime EndDate)
{
    public Guid TransactionId = Guid.NewGuid();

    public bool OccursOnDate(DateTime currentDate)
    {
        if (currentDate < StartDate || currentDate > EndDate)
            return false;

        return Frequency switch
        {
            TransactionFrequencyType.Once => currentDate == StartDate,
            TransactionFrequencyType.Daily => true,
            TransactionFrequencyType.Weekly => currentDate.DayOfWeek == StartDate.DayOfWeek,
            TransactionFrequencyType.Monthly => currentDate.Day == StartDate.Day,
            TransactionFrequencyType.Yearly => currentDate.Day == StartDate.Day && currentDate.Month == StartDate.Month,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public IEnumerable<DateTime> GetTransactionDates()
    {
        return Frequency switch
        {
            TransactionFrequencyType.Once => new[] { StartDate },
            TransactionFrequencyType.Daily => GetDailyTransactionDates(StartDate, EndDate)
                .Where(d => OccursOnDate(d) && d <= EndDate),
            TransactionFrequencyType.Weekly => GetWeeklyTransactionDates(StartDate, EndDate)
                .Where(d => OccursOnDate(d) && d <= EndDate),
            TransactionFrequencyType.Monthly => GetMonthlyTransactionDates(StartDate, EndDate)
                .Where(d => OccursOnDate(d) && d <= EndDate),
            TransactionFrequencyType.Yearly => GetYearlyTransactionDates(StartDate, EndDate)
                .Where(d => OccursOnDate(d) && d <= EndDate),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private IEnumerable<DateTime> GetDailyTransactionDates(DateTime from, DateTime to) => Enumerable.Range(0, (to - from).Days + 1).Select(d => from.AddDays(d));
    private IEnumerable<DateTime> GetWeeklyTransactionDates(DateTime from, DateTime to) => Enumerable.Range(0, (to - from).Days + 1).Select(d => from.AddDays(d)).Where(d => d.DayOfWeek == StartDate.DayOfWeek);
    private IEnumerable<DateTime> GetMonthlyTransactionDates(DateTime from, DateTime to) => Enumerable.Range(0, (to - from).Days + 1).Select(d => from.AddDays(d)).Where(d => d.Day == StartDate.Day);
    private IEnumerable<DateTime> GetYearlyTransactionDates(DateTime from, DateTime to) => Enumerable.Range(0, (to - from).Days + 1).Select(d => from.AddDays(d)).Where(d => d.Day == StartDate.Day && d.Month == StartDate.Month);

}