using Microsoft.Extensions.Caching.Memory;
using Nextech.Business.Cache;
using Nextech.Core.Interfaces;
using Nextech.Core.DTO;
using Nextech.Core.Util;
using System.Threading.Tasks.Dataflow;
using AutoMapper;
using System.Collections.Concurrent;

namespace Nextech.Business;

public class ItemBusiness : IItemBusiness
{
    private readonly IMemoryCache _memoryCache;
    private readonly IItemClient _itemClient;
    private readonly IMapper _mapper;
    private int totalItems;

    public ItemBusiness(
        IMemoryCache memoryCache,
        IItemClient itemClient,
        IMapper mapper)
    {
        _memoryCache = memoryCache;
        _itemClient = itemClient;
        _mapper = mapper;
    }

    public async Task<List<ItemDTO>> ListStories(int currentPage, int pageSize)
    {
        var result = new ConcurrentBag<ItemDTO>();

        var itemsIDList = await GetItemsIDList();
        var itemsListCache = await GetItemsList();
        var updatedItemsIDList = await GetUpdatedItemsIDList();

        if (itemsIDList != null && itemsIDList.Count != 0)
        {
            int totalPages = totalItems / pageSize;
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = startIndex + pageSize >= totalItems ? totalItems : startIndex + pageSize;

            var block = new ActionBlock<int>(
            async itemID =>
            {
                var itemDTO = itemsListCache?.FirstOrDefault(item => item.ID == itemID);

                if (itemDTO == null)
                {
                    itemDTO = await GetItemDTO(itemID);
                    itemsListCache?.Add(itemDTO);
                }
                else
                {
                    var exists = updatedItemsIDList.Exists(id => id == itemID);
                    if (exists)
                    {
                        var value = itemsListCache?.Select((element, index) => new { element, index }).First(item => item.element.ID == itemID);

                        itemsListCache.ToArray()[value.index] = await GetItemDTO(itemID);
                    }
                }

                result.Add(itemDTO);
            },
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = Parameters.MaxDegreeOfParallelism,
            });

            for (int i = startIndex; i < endIndex; i++)
            {
                block.Post(itemsIDList[i]);
            }

            block.Complete();
            await block.Completion;

            _memoryCache.Set(CacheKeys.ItemList, itemsListCache);
        }

        return result.OrderByDescending(item => item.ID).ToList();
    }

    public async Task<List<ItemDTO>> SearchStories(string searchTerm)
    {
        var result = new ConcurrentBag<ItemDTO>();

        var itemsIDList = await GetItemsIDList();
        var itemsListCache = await GetItemsList();

        if (itemsIDList != null && itemsIDList.Count != 0)
        {
            var block = new ActionBlock<int>(
            async itemID =>
            {
                var itemDTO = itemsListCache?.FirstOrDefault(item => item.ID == itemID);

                if (itemDTO == null)
                {
                    itemDTO = await GetItemDTO(itemID);
                    itemsListCache?.Add(itemDTO);
                }

                if (itemDTO.Title != null && itemDTO.Title.ToLower().Contains(searchTerm.ToLower()))
                {
                    result.Add(itemDTO);
                }
                else if (itemDTO.Text != null && itemDTO.Text.ToLower().Contains(searchTerm.ToLower()))
                {
                    result.Add(itemDTO);
                }

            },
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = Parameters.MaxDegreeOfParallelism,
            });

            for (int i = 0; i < totalItems; i++)
            {
                block.Post(itemsIDList[i]);
            }

            block.Complete();
            await block.Completion;

            _memoryCache.Set(CacheKeys.ItemList, itemsListCache);
        }

        return result.OrderByDescending(item => item.ID).ToList();
    }

    public int GetTotal()
    {
        return totalItems;
    }

    #region Private Methods
    private async Task<List<int>> GetItemsIDList()
    {
        var success = _memoryCache.TryGetValue(CacheKeys.ItemIDs, out List<int>? itemsIDList);

        if (!success)
        {
            itemsIDList = await _itemClient.GetItemsAsync();
            _memoryCache.Set(CacheKeys.ItemIDs, itemsIDList);
        }

        totalItems = itemsIDList.Count;

        return itemsIDList;
    }

    private async Task<ConcurrentBag<ItemDTO>> GetItemsList()
    {
        var success = _memoryCache.TryGetValue(CacheKeys.ItemList, out ConcurrentBag<ItemDTO>? itemsListCache);

        if (!success)
        {
            itemsListCache = new ConcurrentBag<ItemDTO>();
        }

        return itemsListCache;
    }

    private async Task<List<int>> GetUpdatedItemsIDList()
    {
        var result = await _itemClient.GetUpdatedItemsAsync();
        return result.Items;
    }

    private async Task<ItemDTO> GetItemDTO(int itemID)
    {
        var item = await _itemClient.GetItemAsync(itemID);
        return _mapper.Map<ItemDTO>(item);
    }
    #endregion 
}