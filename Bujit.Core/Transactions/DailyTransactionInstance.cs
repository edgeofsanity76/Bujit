using Bujit.Core.Enums;

namespace Bujit.Core.Transactions;

public record DailyTransactionInstance(DateTime StartDate, DateTime EndDate, TransactionType TransactionType, decimal Amount) : TransactionInstance(TransactionFrequencyType.Daily, TransactionType, Amount, StartDate, EndDate);