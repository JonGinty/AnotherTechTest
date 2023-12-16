using Microsoft.AspNetCore.Mvc;
using SearchService;

namespace SearchPlatform.Controllers;

/// <summary>
/// Controller for basic search functionality.
/// </summary>
[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase
{
    private readonly ILogger<SearchController> _logger;

    private ISearchService<UserItem> _searchService;

    public SearchController(ILogger<SearchController> logger, ISearchService<UserItem> searchService)
    {
        _logger = logger;
        _searchService = searchService;
    }

    /// <summary>
    /// Searches for users based on the provided search query and returns
    /// the results in an array of <c>UserItem</c>.
    /// </summary>
    /// <param name="searchQuery">A basic search query. Currently does not support wildcards.</param>
    /// <returns>All users that match the search query.</returns>
    [HttpGet("{searchQuery}")]
    public async Task<IEnumerable<UserItem>> Get([FromRoute] string searchQuery)
    {
        _logger.Log(LogLevel.Trace, """Applying search query for {0}.""", searchQuery);
        return await _searchService.Search(searchQuery);
    }
}
