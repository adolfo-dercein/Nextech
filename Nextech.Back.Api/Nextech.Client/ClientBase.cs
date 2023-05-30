using Newtonsoft.Json;
using Nextech.Core.Interfaces;

namespace Nextech.Client;

public class ClientBase : IClientBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ClientBase(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<T> Request<T>(string url) where T : new()
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

        var httpClient = _httpClientFactory.CreateClient();

        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T>(contentStream);
    }
}

