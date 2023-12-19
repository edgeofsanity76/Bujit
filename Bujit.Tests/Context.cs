using Bujit.Core.Enums;
using Bujit.Core.Transactions;

namespace Bujit.Tests;

public class Context
{
    public Transaction GetRandomDailyTransactionInstance(DateTime startDate, DateTime endDate)
    {
        var random = new Random();
        var amount = random.Next(1, 100);
        var transactionType = random.Next(1, 100) % 2 == 0 ? TransactionType.Income : TransactionType.Expense;

        return GetRandomDailyTransactionInstance(startDate, endDate, amount, transactionType);
    }

    public Transaction GetRandomDailyTransactionInstance(DateTime startDate, DateTime endDate, decimal amount, TransactionType transactionType)
    {
        return new DailyTransaction(startDate, endDate, transactionType, amount);
    }

    public Transaction GetRandomWeeklyTransactionInstance(DateTime startDate, DateTime endDate)
    {
        var random = new Random();
        var amount = random.Next(1, 100);
        var transactionType = random.Next(1, 100) % 2 == 0 ? TransactionType.Income : TransactionType.Expense;

        return GetRandomWeeklyTransactionInstance(startDate, endDate, amount, transactionType);
    }

    public Transaction GetRandomWeeklyTransactionInstance(DateTime startDate, DateTime endDate,
        decimal amount, TransactionType transactionType)
    {
        return new WeeklyTransaction(startDate, endDate, transactionType, amount);
    }

    public Transaction GetRandomMonthlyTransactionInstance(DateTime startDate, DateTime endDate)
    {
        var random = new Random();
        var amount = random.Next(1, 100);
        var transactionType = random.Next(1, 100) % 2 == 0 ? TransactionType.Income : TransactionType.Expense;

        return GetRandomMonthlyTransactionInstance(startDate, endDate, amount, transactionType);
    }

    public Transaction GetRandomMonthlyTransactionInstance(DateTime startDate, DateTime endDate,
        decimal amount, TransactionType transactionType)
    {
        return new MonthlyTransaction(startDate, endDate, transactionType, amount);
    }

    public Transaction GetRandomYearlyTransactionInstance(DateTime startDate, DateTime endDate)
    {
        var random = new Random();
        var amount = random.Next(1, 100);
        var transactionType = random.Next(1, 100) % 2 == 0 ? TransactionType.Income : TransactionType.Expense;

        return GetRandomYearlyTransactionInstance(startDate, endDate, amount, transactionType);
    }

    public Transaction GetRandomYearlyTransactionInstance(DateTime startDate, DateTime endDate,
        decimal amount, TransactionType transactionType)
    {
        return new YearlyTransaction(startDate, endDate, transactionType, amount);
    }

    public Transaction GetRandomSingleTransactionInstance(DateTime onDate)
    {
        var random = new Random();
        var amount = random.Next(1, 100);
        var transactionType = random.Next(1, 100) % 2 == 0 ? TransactionType.Income : TransactionType.Expense;

        return GetRandomSingleTransactionInstance(onDate, amount, transactionType);
    }

    public Transaction GetRandomSingleTransactionInstance(DateTime onDate, decimal amount,
        TransactionType transactionType)
    {
        return new SingleTransaction(onDate, transactionType, amount);
    }

}