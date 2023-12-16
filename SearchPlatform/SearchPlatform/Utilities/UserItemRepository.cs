using SearchService;

namespace SearchPlatform.Utilities;

public class UserItemRepository : GenericItemRepository<UserItem>
{
    public UserItemRepository(IEnumerable<UserItem> items) : base(MatchFilter, items)
    {
    }

    private static bool MatchFilter(Query query, UserItem item)
    {
        foreach (var token in query.tokens) {
            // we could user reflection to iterate over the props here
            // or convert it to a dictionary and use the KVP store 
            // but this will perform much better.
            if (item.Id.ToString().Contains(token, StringComparison.CurrentCultureIgnoreCase)) continue;
            if (item.FirstName.Contains(token, StringComparison.CurrentCultureIgnoreCase)) continue;
            if (item.LastName.Contains(token, StringComparison.CurrentCultureIgnoreCase)) continue;
            if (item.Email.Contains(token, StringComparison.CurrentCultureIgnoreCase)) continue;
            if (item.Gender.Contains(token, StringComparison.CurrentCultureIgnoreCase)) continue;
            return false;
        }
        return true;
    }
}
