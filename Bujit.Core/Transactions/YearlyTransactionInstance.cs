using Bujit.Core.Enums;

namespace Bujit.Core.Transactions;

public record YearlyTransactionInstance(DateTime StartDate, DateTime EndDate, TransactionType TransactionType, decimal Amount) : TransactionInstance(TransactionFrequencyType.Yearly, TransactionType, Amount, StartDate, EndDate);