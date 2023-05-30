using Microsoft.Extensions.Caching.Memory;
using Nextech.Core.Interfaces;

namespace Nextech.Api;

public class InitializeCacheService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IItemBusiness _itemBusiness;
    public InitializeCacheService(IServiceProvider serviceProvider, IItemBusiness itemBusiness)
    {
        _serviceProvider = serviceProvider;
        _itemBusiness = itemBusiness;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var cache = _serviceProvider.GetService<IMemoryCache>();

            _itemBusiness.ListStories(1, 400);
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
