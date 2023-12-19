using Bujit.Core.Enums;

namespace Bujit.Core.Transactions;

public record WeeklyTransactionInstance(DateTime StartDate, DateTime EndDate, TransactionType TransactionType, decimal Amount) : TransactionInstance(TransactionFrequencyType.Weekly, TransactionType, Amount, StartDate, EndDate);