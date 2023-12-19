using Bujit.Core.Enums;

namespace Bujit.Core.Transactions;

public record MonthlyTransactionInstance(DateTime StartDate, DateTime EndDate, TransactionType TransactionType, decimal Amount) : TransactionInstance(TransactionFrequencyType.Monthly, TransactionType, Amount, StartDate, EndDate);