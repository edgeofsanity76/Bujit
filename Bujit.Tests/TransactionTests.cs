using Bujit.Core.Extensions;
using Xunit;

namespace Bujit.Tests;

public class TransactionTests(Context context) : IClassFixture<Context>
{
    [Fact]
    public void ShouldReturnCorrectDatesForRepeatingTransactionYearly()
    {
        var currentDateTime = DateTime.UtcNow;

        //Arrange
        var transaction = context.GetRandomYearlyTransactionInstance(currentDateTime, currentDateTime.AddYears(2));

        //Act
        var dates = transaction.GetTransactionDates().ToList();

        //Assert
        Assert.Equal(3, dates.Count);
        Assert.Equal(currentDateTime, dates[0]);
        Assert.Equal(currentDateTime.AddYears(1), dates[1]);
        Assert.Equal(currentDateTime.AddYears(2), dates[2]);
    }

    [Fact]
    public void ShouldReturnCorrectDatesForRepeatingTransactionOnce()
    {
        var currentDateTime = DateTime.UtcNow;

        //Arrange
        var transaction = context.GetRandomSingleTransactionInstance(currentDateTime);

        //Act
        var dates = transaction.GetTransactionDates().ToList();

        //Assert
        Assert.Single(dates);
        Assert.Equal(currentDateTime, dates[0]);
    }

    [Fact]
    public void ShouldReturnCorrectDatesForRepeatingTransactionWeekly()
    {
        var currentDateTime = DateTime.UtcNow;

        //Arrange
        var transaction = context.GetRandomWeeklyTransactionInstance(currentDateTime, currentDateTime.AddDays(10));

        //Act
        var dates = transaction.GetTransactionDates().ToList();

        //Assert
        Assert.Equal(2, dates.Count);
        Assert.Equal(currentDateTime, dates[0]);
        Assert.Equal(currentDateTime.AddDays(7), dates[1]);
    }

    [Fact]
    public void ShouldReturnCorrectDatesForRepeatingTransactionMonthly()
    {
        var currentDateTime = DateTime.UtcNow;

        //Arrange
        var transaction = context.GetRandomMonthlyTransactionInstance(currentDateTime, currentDateTime.AddMonths(2));

        //Act
        var dates = transaction.GetTransactionDates().ToList();

        //Assert
        Assert.Equal(3, dates.Count);
        Assert.Equal(currentDateTime, dates[0]);
        Assert.Equal(currentDateTime.AddMonths(1), dates[1]);
        Assert.Equal(currentDateTime.AddMonths(2), dates[2]);
    }

    [Fact]
    public void ShouldReturnCorrectDatesForRepeatingTransactionDaily()
    {
        var currentDateTime = DateTime.UtcNow;

        //Arrange
        var transactionInstance = context.GetRandomDailyTransactionInstance(currentDateTime, currentDateTime.AddDays(10));

        //Act
        var dates = transactionInstance.GetTransactionDates().ToList();

        //Assert
        Assert.Equal(11, dates.Count);
        Assert.Equal(currentDateTime, dates[0]);
        Assert.Equal(currentDateTime.AddDays(1), dates[1]);
        Assert.Equal(currentDateTime.AddDays(2), dates[2]);
        Assert.Equal(currentDateTime.AddDays(3), dates[3]);
        Assert.Equal(currentDateTime.AddDays(4), dates[4]);
        Assert.Equal(currentDateTime.AddDays(5), dates[5]);
        Assert.Equal(currentDateTime.AddDays(6), dates[6]);
        Assert.Equal(currentDateTime.AddDays(7), dates[7]);
        Assert.Equal(currentDateTime.AddDays(8), dates[8]);
        Assert.Equal(currentDateTime.AddDays(9), dates[9]);
        Assert.Equal(currentDateTime.AddDays(10), dates[10]);
    }
}