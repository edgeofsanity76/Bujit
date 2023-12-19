using Bujit.Core.Enums;

namespace Bujit.Core.Transactions;

public record MonthlyTransaction(DateTime StartDate, DateTime EndDate, TransactionType TransactionType, decimal Amount) : Transaction(TransactionFrequencyType.Monthly, TransactionType, Amount, StartDate, EndDate);