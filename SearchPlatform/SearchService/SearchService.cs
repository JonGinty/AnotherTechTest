using SearchService;

namespace SearchService;

public class SearchService<T> : ISearchService<T>
{
    private readonly IItemRepository<T> _repository;

    public SearchService(IItemRepository<T> repository) => _repository = repository;

    public async Task<IEnumerable<T>> Search(string searchQuery)
    {
        var tokens = searchQuery.Split(' '); // TODO: url decode?
        return await _repository.Find(new Query(tokens));
    }
}
