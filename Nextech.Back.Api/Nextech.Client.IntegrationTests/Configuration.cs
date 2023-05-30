using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Nextech.Business;
using Nextech.Client.Clients;
using Nextech.Core.Interfaces;
using Nextech.Core.MapProfiles;

namespace Nextech.Client.IntegrationTests;

internal class Configuration<T> where T : class
{
    private T instance; 

    public Configuration() 
    {
        var services = new ServiceCollection();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ItemProfile());
        });

        IMapper mapper = mappingConfig.CreateMapper();

        services.AddMemoryCache();
        services.AddHttpClient();

        services.AddTransient<IClientBase, ClientBase>();
        services.AddTransient<IItemClient, ItemClient>();
        services.AddTransient<IItemBusiness, ItemBusiness>();

        var serviceProvider = services.BuildServiceProvider();

        instance = serviceProvider.GetService<T>();
    }

    public T getInstance()
    {
        return instance;
    }
}
