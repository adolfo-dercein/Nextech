
using Nextech.Core.DTO;

namespace Nextech.Core.Interfaces;

public interface IItemBusiness
{
    Task<List<ItemDTO>> ListStories(int pageNumber, int pageSize);
    Task<List<ItemDTO>> SearchStories(string searchItem);
    int GetTotal();
}
