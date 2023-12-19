using Bujit.Core.Enums;
using Bujit.Core.Transactions;

namespace Bujit.Tests;

public class Context
{
    public TransactionInstance GetRandomDailyTransactionInstance(DateTime startDate, DateTime endDate)
    {
        var random = new Random();
        var amount = random.Next(1, 100);
        var transactionType = random.Next(1, 100) % 2 == 0 ? TransactionType.Income : TransactionType.Expense;

        return GetRandomDailyTransactionInstance(startDate, endDate, amount, transactionType);
    }

    public TransactionInstance GetRandomDailyTransactionInstance(DateTime startDate, DateTime endDate, decimal amount, TransactionType transactionType)
    {
        return new DailyTransactionInstance(startDate, endDate, transactionType, amount);
    }

    public TransactionInstance GetRandomWeeklyTransactionInstance(DateTime startDate, DateTime endDate)
    {
        var random = new Random();
        var amount = random.Next(1, 100);
        var transactionType = random.Next(1, 100) % 2 == 0 ? TransactionType.Income : TransactionType.Expense;

        return GetRandomWeeklyTransactionInstance(startDate, endDate, amount, transactionType);
    }

    public TransactionInstance GetRandomWeeklyTransactionInstance(DateTime startDate, DateTime endDate,
        decimal amount, TransactionType transactionType)
    {
        return new WeeklyTransactionInstance(startDate, endDate, transactionType, amount);
    }

    public TransactionInstance GetRandomMonthlyTransactionInstance(DateTime startDate, DateTime endDate)
    {
        var random = new Random();
        var amount = random.Next(1, 100);
        var transactionType = random.Next(1, 100) % 2 == 0 ? TransactionType.Income : TransactionType.Expense;

        return GetRandomMonthlyTransactionInstance(startDate, endDate, amount, transactionType);
    }

    public TransactionInstance GetRandomMonthlyTransactionInstance(DateTime startDate, DateTime endDate,
        decimal amount, TransactionType transactionType)
    {
        return new MonthlyTransactionInstance(startDate, endDate, transactionType, amount);
    }

    public TransactionInstance GetRandomYearlyTransactionInstance(DateTime startDate, DateTime endDate)
    {
        var random = new Random();
        var amount = random.Next(1, 100);
        var transactionType = random.Next(1, 100) % 2 == 0 ? TransactionType.Income : TransactionType.Expense;

        return GetRandomYearlyTransactionInstance(startDate, endDate, amount, transactionType);
    }

    public TransactionInstance GetRandomYearlyTransactionInstance(DateTime startDate, DateTime endDate,
        decimal amount, TransactionType transactionType)
    {
        return new YearlyTransactionInstance(startDate, endDate, transactionType, amount);
    }

    public TransactionInstance GetRandomSingleTransactionInstance(DateTime onDate)
    {
        var random = new Random();
        var amount = random.Next(1, 100);
        var transactionType = random.Next(1, 100) % 2 == 0 ? TransactionType.Income : TransactionType.Expense;

        return GetRandomSingleTransactionInstance(onDate, amount, transactionType);
    }

    public TransactionInstance GetRandomSingleTransactionInstance(DateTime onDate, decimal amount,
        TransactionType transactionType)
    {
        return new SingleTransactionInstance(onDate, transactionType, amount);
    }

}