using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService;

public interface IItemRepository<T>
{
    Task<IEnumerable<T>> Find(Query query);
}

