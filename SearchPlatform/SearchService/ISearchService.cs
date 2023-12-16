namespace SearchService;


public interface ISearchService<T>
{
    Task<IEnumerable<T>> Search(string searchQuery);
}
