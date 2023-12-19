namespace Bujit.Core.Extensions;

public static class AccountExtensions
{
    public static Account UpdateBalance(this Account account, TransactionTimeline transactionTimeline)
    {
        var balance = transactionTimeline.GetBalanceForDateRange(DateTime.MinValue, DateTime.MaxValue, account.Balance).Last().balance;
        return account with { Balance = balance };
    }
}