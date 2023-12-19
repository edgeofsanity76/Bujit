using System.Collections;
using System.Collections.Immutable;
using Bujit.Core.Enums;
using Bujit.Core.Extensions;
using Bujit.Core.Transactions;

namespace Bujit.Core;

public class TransactionTimeline(params Transaction[] transactions) : IEnumerable<Transaction>
{
    private readonly ImmutableList<Transaction> _transactions = transactions.ToImmutableList();

    public TransactionTimeline Add(Transaction transaction) => new(_transactions.Add(transaction).ToArray());

    public TransactionTimeline AddRange(IEnumerable<Transaction> transactions) => new(_transactions.AddRange(transactions.ToArray()).ToArray());

    public TransactionTimeline GetForDate(DateTime currentDate) => new(_transactions.Where(t => t.OccursOnDate(currentDate)).ToArray());

    public TransactionTimeline GetForDateRange(DateTime startDate, DateTime endDate) => new( _transactions.Where(t => t.StartDate >= startDate && t.EndDate <= endDate).ToArray());

    public TransactionTimeline GetForDateRange(DateTime startDate, DateTime endDate, TransactionType transactionType) => new(_transactions
        .Where(t => t.StartDate >= startDate && t.EndDate <= endDate && t.TransactionType == transactionType).ToArray());


    public IEnumerator<Transaction> GetEnumerator()
    {
        return _transactions.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}