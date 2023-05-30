using Nextech.Core.DTO;

namespace Nextech.Core.Response;

public class ItemResponse
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public int Total { get; set; }

    public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();
}