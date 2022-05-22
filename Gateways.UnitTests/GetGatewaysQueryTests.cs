using Gateways;
using Gateways.Domain.Shared.Interfaces;
using Gateways.Service.Queries;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Xunit;

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
        public  void GetGetAllGatewaysQuery_ShouldReturnSuccess()
        {
            //Act
            var result =  _messageDispatcher.DispatchAsync(new GetAllGatewaysQuery());
            //Assert
            Assert.True(result.Result.IsSuccess);
        }
    }
}

