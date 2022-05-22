using Gateways.Domain.Shared.Interfaces;
using Gateways.Service.Queries;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using Gateways.API;

namespace Gateways.UnitTests
{
    public class GetGatewaysQueryTests : IClassFixture<TestApplicationFactory<Startup>>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageDispatcher _messageDispatcher;

        public GetGatewaysQueryTests(TestApplicationFactory<Startup> factory)
        {
            _serviceProvider = factory.Services;
            _messageDispatcher = _serviceProvider.GetService<IMessageDispatcher>();
        }



        [Fact]
        public async Task GetGetAllGatewaysQueryAsync_ShouldResturnTrue()
        {
            //Act
            var result = await _messageDispatcher.DispatchAsync(new GetAllGatewaysQuery());
            //Assert
            Assert.True(result.IsSuccess);


        }

        [Fact]
        public async Task GetGatewayDetailsByIdQueryAsync_ShouldReturnFalse()
        {
            //Act
            var result = await _messageDispatcher.DispatchAsync(new GetGatewayDetailsByIdQuery(null));
            //Assert
            Assert.True(result.IsFailure);

        }

    }
}

