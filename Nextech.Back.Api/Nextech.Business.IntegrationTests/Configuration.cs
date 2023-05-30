using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Nextech.Client;
using Nextech.Client.Clients;
using Nextech.Core.Interfaces;
using Nextech.Core.MapProfiles;

namespace Nextech.Business.IntegrationTests;

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

        services.AddTransient<IItemBusiness, ItemBusiness>();
        services.AddTransient<IItemClient, ItemClient>();
        services.AddTransient<IClientBase, ClientBase>();

        var serviceProvider = services.BuildServiceProvider();

        instance = serviceProvider.GetService<T>();
    }

    public T getInstance()
    {
        return instance;
    }
}
