

using Nextech.Core.Model;

namespace Nextech.Core.Interfaces;

public interface IItemClient
{
    Task<List<int>> GetItemsAsync();
    Task<Item> GetItemAsync(int id);
    Task<UpdatedInfo> GetUpdatedItemsAsync();
}
