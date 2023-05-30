using Nextech.Core.Interfaces;

namespace Nextech.Client.IntegrationTests.Item;

[TestClass]
public class ItemClientTest
{
    public readonly IItemClient _itemClient;

    public ItemClientTest()
    {
        var configuration = new Configuration<IItemClient>();
        _itemClient = configuration.getInstance();
    }

    [TestMethod]
    public async Task GetItemsAsync_IsNotNull()
    {
        var result = await _itemClient.GetItemsAsync();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetItemsAsync_HasResults()
    {
        var result = await _itemClient.GetItemsAsync();
        Assert.IsTrue(result.Count > 0);
    }

    [TestMethod]
    public async Task GetItemAsync_WhenValidItemId_IsNotNull()
    {
        var result = await _itemClient.GetItemAsync(123);
        Assert.IsNotNull(result);
    }
}