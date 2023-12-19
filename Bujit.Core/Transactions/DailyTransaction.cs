using Bujit.Core.Enums;

namespace Bujit.Core.Transactions;

public record DailyTransaction(DateTime StartDate, DateTime EndDate, TransactionType TransactionType, decimal Amount) : Transaction(TransactionFrequencyType.Daily, TransactionType, Amount, StartDate, EndDate);