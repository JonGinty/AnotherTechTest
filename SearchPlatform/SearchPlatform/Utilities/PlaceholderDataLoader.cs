
using System.Text.Json;
using System.IO;
using SearchService;


namespace SearchPlatform.Utilities;

public class PlaceholderDataLoader
{
    public UserItem[] LoadItems()
    {
        using var reader = new StreamReader("data.json");
        var items = JsonSerializer.Deserialize<UserItem[]>(reader.ReadToEnd(), new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower });
        if (items == null) throw new InvalidOperationException($"{nameof(items)} was unexpectedly null.");
        return items;
    }

    //private Dictionary<string, string> UserItemToDictionary(UserItem item)
    //    => new()
    //    {
    //        { nameof(UserItem.Id), item.Id.ToString() },
    //        {nameof(UserItem.FirstName), item.FirstName },
    //        {nameof(UserItem.LastName), item.LastName },
    //        {nameof(UserItem.Email), item.Email },
    //        {nameof(UserItem.Gender), item.Gender },
    //    };

    //public static KvpItemRepository LoadRepositoryFromItems(UserItem[] items)
    //   => new KvpItemRepository(items.Select(UserItemToDictionary));

    //public static KvpItemRepository LoadItemsIntoKvpRepo()
    //{
    //    var items = LoadItems();
    //    if (items == null) throw new InvalidOperationException("items must not be null.");
    //    return LoadRepositoryFromItems(items);
    //}

    public UserItemRepository LoadUserItemRepository()
    {
        var items = LoadItems();
        if (items == null) throw new InvalidOperationException(nameof(items) + " was null.");
        return new UserItemRepository(items);
    }
}
