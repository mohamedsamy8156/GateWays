using Gateways;
using Gateways.Domain.Shared.Interfaces;
using Gateways.Service.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        }




        [Fact]
        [TestMethod]
        public async Task GetGetAllGatewaysQueryAsync()
        {
            //Act
            var result = await _messageDispatcher.DispatchAsync(new GetAllGatewaysQuery());
            //Assert
            Assert.IsTrue(result.IsSuccess);
        }
    }
}

