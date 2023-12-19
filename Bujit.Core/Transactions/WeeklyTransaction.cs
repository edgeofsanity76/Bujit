using Bujit.Core.Enums;

namespace Bujit.Core.Transactions;

public record WeeklyTransaction(DateTime StartDate, DateTime EndDate, TransactionType TransactionType, decimal Amount) : Transaction(TransactionFrequencyType.Weekly, TransactionType, Amount, StartDate, EndDate);