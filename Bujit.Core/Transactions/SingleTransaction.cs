using Bujit.Core.Enums;

namespace Bujit.Core.Transactions;

public record SingleTransaction(DateTime OnDate, TransactionType TransactionType, decimal Amount) : Transaction(TransactionFrequencyType.Once, TransactionType, Amount, OnDate, OnDate);