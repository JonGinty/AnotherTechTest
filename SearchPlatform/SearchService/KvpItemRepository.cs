using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService;

public class KvpItemRepository : GenericItemRepository<IDictionary<string, string>>
{
    public KvpItemRepository(IEnumerable<IDictionary<string, string>> items) : base(ItemFilter, items)
    {

    }

    private static bool ItemFilter(Query query, IDictionary<string, string> item)
    {
        foreach (var token in query.tokens)
        {
            if (!item.Values.Any(v => v.Contains(token, StringComparison.CurrentCultureIgnoreCase)))
            {
                return false;
            }
        }
        return true;
    }
        // I originally had this method as the one-liner below but to be honest it's actually much less readable than with loops
        //
        //=> !query
        //        .tokens
        //        .Any(token => !item.Values.Any(v => v.Contains(token, StringComparison.CurrentCultureIgnoreCase)));
}

