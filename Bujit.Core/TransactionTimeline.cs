using System.Collections;
using System.Collections.Immutable;
using Bujit.Core.Enums;
using Bujit.Core.Transactions;

namespace Bujit.Core;

public class TransactionTimeline(params TransactionInstance[] transactions) : IEnumerable<TransactionInstance>
{
    private readonly ImmutableList<TransactionInstance> _transactions = transactions.ToImmutableList();

    public TransactionTimeline Add(TransactionInstance transactionInstance) => new(_transactions.Add(transactionInstance).ToArray());

    public TransactionTimeline AddRange(IEnumerable<TransactionInstance> transactions) => new(_transactions.AddRange(transactions.ToArray()).ToArray());

    public TransactionTimeline GetForDate(DateTime currentDate) => new(_transactions.Where(t => t.OccursOnDate(currentDate)).ToArray());

    public TransactionTimeline GetForDateRange(DateTime startDate, DateTime endDate) => new( _transactions.Where(t => t.StartDate >= startDate && t.EndDate <= endDate).ToArray());

    public TransactionTimeline GetForDateRange(DateTime startDate, DateTime endDate, TransactionType transactionType) => new(_transactions
        .Where(t => t.StartDate >= startDate && t.EndDate <= endDate && t.TransactionType == transactionType).ToArray());


    public IEnumerator<TransactionInstance> GetEnumerator()
    {
        return _transactions.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}