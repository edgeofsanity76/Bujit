using Bujit.Core.Enums;

namespace Bujit.Core.Transactions;

public record YearlyTransaction(DateTime StartDate, DateTime EndDate, TransactionType TransactionType, decimal Amount) : Transaction(TransactionFrequencyType.Yearly, TransactionType, Amount, StartDate, EndDate);