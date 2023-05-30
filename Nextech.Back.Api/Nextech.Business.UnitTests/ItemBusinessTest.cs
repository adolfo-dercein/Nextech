
namespace Nextech.Business.UnitTests;

[TestClass]
public class ItemBusinessTest
{
    [TestMethod]
    public async Task ListStories_Result_IsNotNull()
    {
        var configuration = new Configuration();    

        var mockItemClient = configuration.GetMockItemClient();
        var mapper = configuration.GetMapper();
        var cache = configuration.GetCache();

        var itemBusiness = new ItemBusiness(cache, mockItemClient.Object, mapper);

        var result = await itemBusiness.ListStories(1, 100);

        Assert.IsNotNull(result);   
    }

    [TestMethod]
    public async Task SearchStories_Result_IsNotNull()
    {
        var configuration = new Configuration();

        var mockItemClient = configuration.GetMockItemClient();
        var mapper = configuration.GetMapper();
        var cache = configuration.GetCache();

        var itemBusiness = new ItemBusiness(cache, mockItemClient.Object, mapper);

        var result = await itemBusiness.SearchStories("title");

        Assert.IsNotNull(result);
    }
}