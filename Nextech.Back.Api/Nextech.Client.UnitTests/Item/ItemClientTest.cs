using Microsoft.Extensions.Options;
using Nextech.Client.Clients;
using Nextech.Core.Util;

namespace Nextech.Client.UnitTests.Item;

[TestClass]
public class ItemClientTest
{
    [TestMethod]
    public async Task GetItemAsync_WhenValidItemId_IsNotNull()
    {   
        //var mockHttpClientFactory = Configuration.GetMockHttpClientFactoryForGetItems();

        //ItemClient itemClient = new ItemClient(mockHttpClientFactory.Object);

        //var result = await itemClient.GetItemAsync(8863);

        //Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetItemsAsync_IsNotNull()
    {
        //var mockHttpClientFactory = Configuration.GetMockHttpClientFactoryForGetItem();

        //ItemClient itemClient = new ItemClient(mockHttpClientFactory.Object);

        //var result = await itemClient.GetItemsAsync();

        //Assert.IsNotNull(result);
    }
}