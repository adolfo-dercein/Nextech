using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Nextech.Core.Interfaces;
using Nextech.Core.MapProfiles;
using Nextech.Core.Model;
using System;

namespace Nextech.Business.UnitTests
{
    public class Configuration
    {
        private IMapper _mapper;
        private IMemoryCache _cache;

        public Configuration()
        {
            var services = new ServiceCollection();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ItemProfile());
            });

            services.AddMemoryCache();

            _mapper = mappingConfig.CreateMapper();

            var serviceProvider = services.BuildServiceProvider();
            _cache = serviceProvider.GetService<IMemoryCache>();
        }

        public IMapper GetMapper () => _mapper;
        public IMemoryCache GetCache () => _cache;

        public Mock<IItemClient> GetMockItemClient()
        {
            var mockItemClient = new Mock<IItemClient>();

            mockItemClient.Setup(item => item.GetItemsAsync())
                          .ReturnsAsync(
                                new List<int>
                                {
                                    123456,
                                    345512,
                                    545623,
                                    564563
                                });

            mockItemClient.Setup(item => item.GetUpdatedItemsAsync())
                          .ReturnsAsync(
                            new UpdatedInfo
                            {
                                Items = new List<int> { 123456, 987654 },
                                Profiles = new List<string> { "user1", "user2" }
                            });

            mockItemClient.Setup(item => item.GetItemAsync(It.IsAny<int>()))
                          .ReturnsAsync(
                                new Item() { id = 345512, title = "noticia" }
                          );
                          
            return mockItemClient;
        }
    }
}
