using Microsoft.AspNetCore.Mvc;
using Nextech.Core.Interfaces;
using Nextech.Core.Response;

namespace Nextech.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemBusiness _itemBusiness;

    public ItemController(IItemBusiness itemBusiness)
    {
        _itemBusiness = itemBusiness;
    }

    [HttpGet("GetStories")]
    public async Task<Response<ItemResponse>> GetStories(int pageNumber, int pageSize)
    {
        var response = new Response<ItemResponse>();

        if (pageNumber <= 0) 
        {
            return BadRequest("Page Number cannot be Zero or Negative");
        }
        if (pageSize <= 0)
        {
            return BadRequest("Page Size cannot be Zero or Negative");
        }

        try
        {
            response.Data.Items = await _itemBusiness.ListStories(pageNumber, pageSize);
            response.Data.Total = _itemBusiness.GetTotal();    
            response.Data.PageNumber = pageNumber;
            response.Data.PageSize = pageSize;  

            response.StatusCode = System.Net.HttpStatusCode.OK;
            response.Success = true;
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return response;
    }

    [HttpGet("SearchStories")]
    public async Task<Response<ItemResponse>> SearchStories(string searchTerm)
    {
        var response = new Response<ItemResponse>();

        searchTerm = searchTerm.Trim();

        if(searchTerm.Length == 0 || searchTerm == null || searchTerm == string.Empty)
        {
            return BadRequest("Search term cannot be empty");
        }

        try
        {
            response.Data.Items = await _itemBusiness.SearchStories(searchTerm);
            response.Data.Total = _itemBusiness.GetTotal();

            response.StatusCode = System.Net.HttpStatusCode.OK;
            response.Success = true;
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return response;
    }

    private Response<ItemResponse> BadRequest(string message)
    {
        return new Response<ItemResponse>()
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Success = false,
            Message = message
        };
    }
}
