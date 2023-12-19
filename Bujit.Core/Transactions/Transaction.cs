using Bujit.Core.Enums;

namespace Bujit.Core.Transactions;

public abstract record Transaction(TransactionFrequencyType Frequency, TransactionType TransactionType, decimal Amount, DateTime StartDate, DateTime EndDate)
{
    public Guid TransactionId = Guid.NewGuid();
}