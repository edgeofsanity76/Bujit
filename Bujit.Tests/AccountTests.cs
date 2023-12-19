using Bujit.Core;
using Bujit.Core.Enums;
using Bujit.Core.Extensions;
using Xunit;

namespace Bujit.Tests;

public class AccountTests(Context context) : IClassFixture<Context>
{
    [Fact]
    public void ShouldUpdateBalance()
    {
        //Arrange
        var account = new Account("Test Account");
        var transaction = context.GetRandomSingleTransactionInstance(DateTime.UtcNow, 100, TransactionType.Income);
        var transactionTimeline = new TransactionTimeline(transaction);

        //Act
        account = account.UpdateBalance(transactionTimeline);

        //Assert
        Assert.Equal(100, account.Balance);
        
    }

    [Fact]
    public void ShouldUpdateBalanceForMultipleTransactions()
    {
        //Arrange
        var account = new Account("Test Account");
        var transaction1 = context.GetRandomSingleTransactionInstance(DateTime.UtcNow, 100, TransactionType.Income);
        var transaction2 = context.GetRandomSingleTransactionInstance(DateTime.UtcNow.AddDays(1), 100, TransactionType.Income);
        var transactionTimeline = new TransactionTimeline(transaction1, transaction2);

        //Act
        account = account.UpdateBalance(transactionTimeline);
        Assert.Equal(200, account.Balance);
    }

    [Fact]
    public void ShouldUpdateBalanceForMultipleTransactionsWithDifferentTypes()
    {
        //Arrange
        var account = new Account("Test Account");
        var transaction1 = context.GetRandomSingleTransactionInstance(DateTime.UtcNow, 100, TransactionType.Income);
        var transaction2 = context.GetRandomSingleTransactionInstance(DateTime.UtcNow.AddDays(1), 100, TransactionType.Expense);
        var transactionTimeline = new TransactionTimeline(transaction1, transaction2);

        //Act
        account = account.UpdateBalance(transactionTimeline);
        Assert.Equal(0, account.Balance);
    }

    [Fact]
    public void ShouldUpdateBalanceForMultipleTransactionsWithDifferentTypesAndDates()
    {
        //Arrange
        var account = new Account("Test Account");
        var transaction1 = context.GetRandomSingleTransactionInstance(DateTime.UtcNow, 100, TransactionType.Income);
        var transaction2 = context.GetRandomSingleTransactionInstance(DateTime.UtcNow.AddDays(1), 100, TransactionType.Expense);
        var transaction3 = context.GetRandomSingleTransactionInstance(DateTime.UtcNow.AddDays(2), 100, TransactionType.Income);
        var transactionTimeline = new TransactionTimeline(transaction1, transaction2, transaction3);

        //Act
        account = account.UpdateBalance(transactionTimeline);
        Assert.Equal(100, account.Balance);
    }

    [Fact]
    public void ShouldUpdateBalanceForMultipleTransactionsWithDifferentTypesAndDatesAndRepeating()
    {
        //Arrange
        var account = new Account("Test Account");
        var transaction1 = context.GetRandomSingleTransactionInstance(DateTime.UtcNow, 100, TransactionType.Income);
        var transaction2 = context.GetRandomSingleTransactionInstance(DateTime.UtcNow.AddDays(1), 100, TransactionType.Expense);
        var transaction3 = context.GetRandomWeeklyTransactionInstance(DateTime.UtcNow, DateTime.UtcNow.AddDays(14), 100, TransactionType.Income);
        var transactionTimeline = new TransactionTimeline(transaction1, transaction2, transaction3);

        //Act
        account = account.UpdateBalance(transactionTimeline);
        Assert.Equal(300, account.Balance);
    }

    [Fact]
    public void ShouldUpdateBalanceForMultipleTransactionsWithDifferentTypesAndDatesAndRepeatingAndMultipleInstances()
    {
        //Arrange
        var account = new Account("Test Account");
        var transaction1 = context.GetRandomSingleTransactionInstance(DateTime.UtcNow, 100, TransactionType.Income);
        var transaction2 = context.GetRandomSingleTransactionInstance(DateTime.UtcNow.AddDays(1), 100, TransactionType.Expense);
        var transaction3 = context.GetRandomWeeklyTransactionInstance(DateTime.UtcNow.AddDays(2), DateTime.UtcNow.AddDays(10), 100, TransactionType.Income);
        var transaction4 = context.GetRandomWeeklyTransactionInstance(DateTime.UtcNow.AddDays(2), DateTime.UtcNow.AddDays(10), 100, TransactionType.Expense);
        var transactionTimeline = new TransactionTimeline(transaction1, transaction2, transaction3, transaction4);

        //Act
        account = account.UpdateBalance(transactionTimeline);
        Assert.Equal(0, account.Balance);
    }
}