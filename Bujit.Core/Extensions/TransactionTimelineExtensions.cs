using Bujit.Core.Enums;
using Bujit.Core.Transactions;

namespace Bujit.Core.Extensions;

public static class TransactionTimelineExtensions
{
    public static IEnumerable<(Transaction transactionInstance, DateTime occursOn, decimal balance)> GetBalanceForDateRange(this TransactionTimeline transactionTimeline, DateTime
        startDate, DateTime endDate, decimal currentBalance)
    {
        var transactionInstances = transactionTimeline.GetForDateRange(startDate, endDate);

        foreach (var transactionInstance in transactionInstances)
        {
            var transactionDates = transactionInstance.GetTransactionDates();

            foreach (var occursOn in transactionDates)
            {
                switch (transactionInstance.TransactionType)
                {
                    case TransactionType.Income:
                        currentBalance += transactionInstance.Amount;
                        break;
                    case TransactionType.Expense:
                        currentBalance -= transactionInstance.Amount;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                yield return (transactionInstance, occursOn, currentBalance);
            }
                
        }
    }
}