
using Nextech.Core.Util;
using M = Nextech.Core.Model;

namespace Nextech.Client.UnitTests
{
    [TestClass]
    public class ClientBaseTest
    {
        [TestMethod]
        public async Task Request_ForTopStoriesEndPoint_IsNotNull()
        {
            var endpoint = Parameters.TopStoriesUrl;

            var mockHttpClientFactory = Configuration.GetMockHttpClientFactoryForGetItems();

            ClientBase clientBase = new ClientBase(mockHttpClientFactory.Object);

            var result = await clientBase.Request<List<int>>(endpoint);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Request_ForGetItemInfoEndPoint_IsNotNull()
        {
            var endpoint = Parameters.ItemInfoUrl;

            var mockHttpClientFactory = Configuration.GetMockHttpClientFactoryForGetItem();

            ClientBase clientBase = new ClientBase(mockHttpClientFactory.Object);

            var result = await clientBase.Request<M.Item>(endpoint);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Request_ForUpdatedItemsEndPoint_IsNotNull()
        {
            var endpoint = Parameters.UpdatedItemsUrl;

            var mockHttpClientFactory = Configuration.GetMockHttpClientFactoryForUpdatedItem();

            ClientBase clientBase = new ClientBase(mockHttpClientFactory.Object);

            var result = await clientBase.Request<M.UpdatedInfo>(endpoint);

            Assert.IsNotNull(result);
        }
    }
}
