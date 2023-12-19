using Bujit.Core.Extensions;

namespace Bujit.Core;

public record Account(string Name)
{
    public decimal Balance { get; init; } = 0;

    public Account UpdateBalance(TransactionTimeline transactionTimeline)
    {
        var balance = transactionTimeline.GetBalanceForDateRange(DateTime.MinValue, DateTime.MaxValue, Balance).Last().balance;
        return this with { Balance = balance };
    }
}