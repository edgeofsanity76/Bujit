using Bujit.Core;
using Bujit.Core.Enums;
using Bujit.Core.Extensions;
using Xunit;

namespace Bujit.Tests;

public class TransactionTimelineTests(Context context) : IClassFixture<Context>
{
    [Fact]
    public void ShouldCalculateTotalForDailyIncomeTransactions()
    {
        var currentDateTime = DateTime.UtcNow;

        //Arrange
        var transaction = context.GetRandomDailyTransactionInstance(currentDateTime, currentDateTime.AddDays(10), 100, TransactionType.Income);
        var transactionTimeline = new TransactionTimeline(transaction);

        //Act
        var balance = transactionTimeline.GetBalanceForDateRange(currentDateTime, currentDateTime.AddDays(10), 0).ToList();

        //Assert
        Assert.Equal(11, balance.Count);
        Assert.Equal(100, balance[0].balance);
        Assert.Equal(200, balance[1].balance);
        Assert.Equal(300, balance[2].balance);
        Assert.Equal(400, balance[3].balance);
        Assert.Equal(500, balance[4].balance);
        Assert.Equal(600, balance[5].balance);
        Assert.Equal(700, balance[6].balance);
        Assert.Equal(800, balance[7].balance);
        Assert.Equal(900, balance[8].balance);
        Assert.Equal(1000, balance[9].balance);
        Assert.Equal(1100, balance[10].balance);
    }

    [Fact]
    public void ShouldCalculateTotalForDailyExpenseTransactions()
    {
        var currentDateTime = DateTime.UtcNow;

        //Arrange
        var transaction = context.GetRandomDailyTransactionInstance(currentDateTime, currentDateTime.AddDays(10), 100, TransactionType.Expense);
        var transactionTimeline = new TransactionTimeline(transaction);

        //Act
        var balance = transactionTimeline.GetBalanceForDateRange(currentDateTime, currentDateTime.AddDays(10), 0).ToList();

        //Assert
        Assert.Equal(11, balance.Count);
        Assert.Equal(-100, balance[0].balance);
        Assert.Equal(-200, balance[1].balance);
        Assert.Equal(-300, balance[2].balance);
        Assert.Equal(-400, balance[3].balance);
        Assert.Equal(-500, balance[4].balance);
        Assert.Equal(-600, balance[5].balance);
        Assert.Equal(-700, balance[6].balance);
        Assert.Equal(-800, balance[7].balance);
        Assert.Equal(-900, balance[8].balance);
        Assert.Equal(-1000, balance[9].balance);
        Assert.Equal(-1100, balance[10].balance);
    }

    [Fact]
    public void ShouldCalculateTotalForWeeklyIncomeTransactions()
    {
        var currentDateTime = DateTime.UtcNow;

        //Arrange
        var transaction = context.GetRandomWeeklyTransactionInstance(currentDateTime, currentDateTime.AddDays(20), 100, TransactionType.Income);
        var transactionTimeline = new TransactionTimeline(transaction);

        //Act
        var balance = transactionTimeline.GetBalanceForDateRange(currentDateTime, currentDateTime.AddDays(21), 0).ToList();

        //Assert
        Assert.Equal(3, balance.Count);
        Assert.Equal(100, balance[0].balance);
        Assert.Equal(200, balance[1].balance);
        Assert.Equal(300, balance[2].balance);
    }

    [Fact]
    public void ShouldCalculateTotalForWeeklyExpenseTransactions()
    {
        var currentDateTime = DateTime.UtcNow;

        //Arrange
        var transaction = context.GetRandomWeeklyTransactionInstance(currentDateTime, currentDateTime.AddDays(20), 100, TransactionType.Expense);
        var transactionTimeline = new TransactionTimeline(transaction);

        //Act
        var balance = transactionTimeline.GetBalanceForDateRange(currentDateTime, currentDateTime.AddDays(21), 0).ToList();

        //Assert
        Assert.Equal(3, balance.Count);
        Assert.Equal(-100, balance[0].balance);
        Assert.Equal(-200, balance[1].balance);
        Assert.Equal(-300, balance[2].balance);
    }

    [Fact]
    public void ShouldCalculateTotalForMonthlyIncomeTransactions()
    {
        var currentDateTime = DateTime.UtcNow;

        //Arrange
        var transaction = context.GetRandomMonthlyTransactionInstance(currentDateTime, currentDateTime.AddMonths(2), 100, TransactionType.Income);
        var transactionTimeline = new TransactionTimeline(transaction);

        //Act
        var balance = transactionTimeline.GetBalanceForDateRange(currentDateTime, currentDateTime.AddMonths(2), 0).ToList();

        //Assert
        Assert.Equal(3, balance.Count);
        Assert.Equal(100, balance[0].balance);
        Assert.Equal(200, balance[1].balance);
        Assert.Equal(300, balance[2].balance);
    }

    [Fact]
    public void ShouldCalculateTotalForMonthlyExpenseTransactions()
    {
        var currentDateTime = DateTime.UtcNow;

        //Arrange
        var transaction = context.GetRandomMonthlyTransactionInstance(currentDateTime, currentDateTime.AddMonths(2), 100, TransactionType.Expense);
        var transactionTimeline = new TransactionTimeline(transaction);

        //Act
        var balance = transactionTimeline.GetBalanceForDateRange(currentDateTime, currentDateTime.AddMonths(2), 0).ToList();

        //Assert
        Assert.Equal(3, balance.Count);
        Assert.Equal(-100, balance[0].balance);
        Assert.Equal(-200, balance[1].balance);
        Assert.Equal(-300, balance[2].balance);
    }
}