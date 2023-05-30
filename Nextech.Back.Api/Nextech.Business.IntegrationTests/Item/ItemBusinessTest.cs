using Nextech.Core.Interfaces;

namespace Nextech.Business.IntegrationTests.Item;

[TestClass]
public class ItemBusinessTest
{
    public readonly IItemBusiness _itemBusiness;

    public ItemBusinessTest()
    {
        var configuration = new Configuration<IItemBusiness>();
        _itemBusiness = configuration.getInstance();
    }


    [TestMethod]
    public async Task ListNews_Result_IsNotNull()
    {
        var result = await _itemBusiness.ListStories(1, 10);
        Assert.IsNotNull(result);
    }

    [TestMethod]    
    public async Task ListNews_CountIsNotZero_IsTrue()
    {
        var result = await _itemBusiness.ListStories(1, 10);
        Assert.IsTrue(result.Count != 0);
    }

    [TestMethod]
    public async Task ListNews_AmountRequestedEqualsToResult_True()
    {
        var newsAmount = 10;

        var result = await _itemBusiness.ListStories(1, newsAmount);

        Assert.IsTrue(result.Count == newsAmount);
    }


    [TestMethod]
    public async Task SearchNews_WithSearchParam_IsNotNull()
    {
        var searchParam = "Git";

        var result = await _itemBusiness.SearchStories(searchParam);

        Assert.IsNotNull(result);
    }
}
