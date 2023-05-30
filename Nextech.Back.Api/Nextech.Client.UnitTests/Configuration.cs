
using Moq.Protected;
using Moq;
using System.Net;

namespace Nextech.Client.UnitTests;

public static class Configuration
{
    public static Mock<IHttpClientFactory> GetMockHttpClientFactoryForGetItem()
    {
        string content = @"{
                            'by' : 'dhouston',  
                            'descendants' : 71, 
                            'id' : 8863, 
                            'kids' : [ 8952, 9224, 8917, 8884, 8887, 8943, 8869, 8958, 9005, 9671, 8940 ], 
                            'score' : 111, 
                            'title' : 'My YC app: Dropbox - Throw away your USB drive', 
                            'type' : 'story', 
                            'url' : 'http://www.getdropbox.com/u/2/screencast.html' 
                            }";

        var mockHttpClientFactory = LoadMockHttpClientFactory(content);

        return mockHttpClientFactory;
    }

    public static Mock<IHttpClientFactory> GetMockHttpClientFactoryForGetItems()
    {
        string content = @"[ 9129911, 9129199, 9127761, 9128141, 9128264, 9127792, 9129248, 9127092, 9128367, 9038733 ]";

        var mockHttpClientFactory = LoadMockHttpClientFactory(content);

        return mockHttpClientFactory;
    }

    public static Mock<IHttpClientFactory> GetMockHttpClientFactoryForUpdatedItem()
    {
        string content = @"{
                              'items' : [ 8423305, 8420805, 8423379, 8422504, 8423178, 8423336, 8422717, 8417484 ],
                              'profiles' : [ 'thefox', 'mdda' ]
                           }";

        var mockHttpClientFactory = LoadMockHttpClientFactory(content);

        return mockHttpClientFactory;
    }

    private static Mock<IHttpClientFactory> LoadMockHttpClientFactory(string content)
    {
        var mockHttpClientFactory = new Mock<IHttpClientFactory>();

        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(content),
            });

        var client = new HttpClient(mockHttpMessageHandler.Object);
        mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

        return mockHttpClientFactory;
    }
}
