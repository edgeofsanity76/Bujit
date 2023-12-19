using Bujit.Core.Enums;

namespace Bujit.Core.Transactions;

public record SingleTransactionInstance(DateTime OnDate, TransactionType TransactionType, decimal Amount) : TransactionInstance(TransactionFrequencyType.Once, TransactionType, Amount, OnDate, OnDate);