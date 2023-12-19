using Bujit.Core.Enums;
using Bujit.Core.Transactions;

namespace Bujit.Core.Extensions;

public static class TransactionTimelineExtensions
{
    public static IEnumerable<(TransactionInstance transactionInstance, DateTime occursOn, decimal balance)> GetBalanceForDateRange(this TransactionTimeline transactionTimeline, DateTime
        startDate, DateTime endDate, decimal currentBalance)
    {
        var transactionInstances = transactionTimeline.GetForDateRange(startDate, endDate);

        foreach (var transactionInstance in transactionInstances)
        {
            currentBalance += transactionInstance.TransactionType switch
            {
                TransactionType.Income => transactionInstance.Amount,
                TransactionType.Expense => -transactionInstance.Amount,
                _ => throw new ArgumentOutOfRangeException()
            };

            var transactionDates = transactionInstance.GetTransactionDates();

            foreach (var occursOn in transactionDates)
                yield return (transactionInstance, occursOn, currentBalance);
        }
    }
}