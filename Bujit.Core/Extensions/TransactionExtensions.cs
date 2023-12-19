using Bujit.Core.Enums;
using Bujit.Core.Transactions;

namespace Bujit.Core.Extensions;

public static class TransactionExtensions
{
    public static bool OccursOnDate(this Transaction transaction, DateTime currentDate)
    {
        if (currentDate < transaction.StartDate || currentDate > transaction.EndDate)
            return false;

        return transaction.Frequency switch
        {
            TransactionFrequencyType.Once => currentDate == transaction.StartDate,
            TransactionFrequencyType.Daily => true,
            TransactionFrequencyType.Weekly => currentDate.DayOfWeek == transaction.StartDate.DayOfWeek,
            TransactionFrequencyType.Monthly => currentDate.Day == transaction.StartDate.Day,
            TransactionFrequencyType.Yearly => currentDate.Day == transaction.StartDate.Day && currentDate.Month == transaction.StartDate.Month,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static bool OccursToday(this Transaction transaction) => transaction.OccursOnDate(DateTime.Today);

    public static IEnumerable<DateTime> GetTransactionDates(this Transaction transaction)
    {
        return transaction.Frequency switch
        {
            TransactionFrequencyType.Once => new[] { transaction.StartDate },
            TransactionFrequencyType.Daily => GetDailyTransactionDates(transaction.StartDate, transaction.EndDate).Where(d => OccursOnDate(transaction, d) && d <= transaction.EndDate),
            TransactionFrequencyType.Weekly => GetWeeklyTransactionDates(transaction, transaction.StartDate, transaction.EndDate).Where(d => OccursOnDate(transaction, d) && d <= transaction.EndDate),
            TransactionFrequencyType.Monthly => GetMonthlyTransactionDates(transaction, transaction.StartDate, transaction.EndDate).Where(d => OccursOnDate(transaction, d) && d <= transaction.EndDate),
            TransactionFrequencyType.Yearly => GetYearlyTransactionDates(transaction, transaction.StartDate, transaction.EndDate).Where(d => OccursOnDate(transaction, d) && d <= transaction.EndDate),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    //TODO: Refactor these methods to be more efficient
    private static IEnumerable<DateTime> GetDailyTransactionDates(DateTime from, DateTime to) => Enumerable.Range(0, (to - from).Days + 1).Select(d => from.AddDays(d));
    private static IEnumerable<DateTime> GetWeeklyTransactionDates(Transaction transaction, DateTime from, DateTime to) => Enumerable.Range(0, (to - from).Days + 1).Select(d => from.AddDays(d)).Where(d => d.DayOfWeek == transaction.StartDate.DayOfWeek);
    private static IEnumerable<DateTime> GetMonthlyTransactionDates(Transaction transaction, DateTime from, DateTime to) => Enumerable.Range(0, (to - from).Days + 1).Select(d => from.AddDays(d)).Where(d => d.Day == transaction.StartDate.Day);
    private static IEnumerable<DateTime> GetYearlyTransactionDates(Transaction transaction, DateTime from, DateTime to) => Enumerable.Range(0, (to - from).Days + 1).Select(d => from.AddDays(d)).Where(d => d.Day == transaction.StartDate.Day && d.Month == transaction.StartDate.Month);
}