using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService;

public class GenericItemRepository<T> : IItemRepository<T>
{
    private Func<Query, T, bool> _matchFilter;
    private IEnumerable<T> _items;

    public GenericItemRepository(Func<Query, T, bool> matchFilter, IEnumerable<T> items)
    {
        _matchFilter = matchFilter;
        _items = items;
    }

    public Task<IEnumerable<T>> Find(Query query)
        => Task.FromResult(_items.Where(item => _matchFilter(query, item)));
}
