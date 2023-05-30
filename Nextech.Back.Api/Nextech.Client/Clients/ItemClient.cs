using Nextech.Core.Interfaces;
using Nextech.Core.Model;
using Nextech.Core.Util;

namespace Nextech.Client.Clients;

public class ItemClient : IItemClient
{
    private readonly IClientBase _clientBase;

    public ItemClient(IClientBase clientBase)
    {
        _clientBase = clientBase;
    }

    public async Task<List<int>> GetItemsAsync()
    {
        return await _clientBase.Request<List<int>>(Parameters.TopStoriesUrl);
    }

    public async Task<Item> GetItemAsync(int id)
    {
        return await _clientBase.Request<Item>(Parameters.ItemInfoUrl.Replace("{{id}}", id.ToString()));
    }

    public async Task<UpdatedInfo> GetUpdatedItemsAsync()
    {
        return await _clientBase.Request<UpdatedInfo>(Parameters.UpdatedItemsUrl);
    }
}