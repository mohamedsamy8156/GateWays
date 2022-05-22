using Gateways.API;
using Gateways.Domain.Shared.Interfaces;
using Gateways.UnitTests;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Gateways.Commands.Commands;
using Gateways.Commands.Models;
using System.Collections.Generic;

namespace Gateways.Tests
{
    public class AddGatewayCommandTests : IClassFixture<TestApplicationFactory<Startup>>
    { 
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageDispatcher _messageDispatcher;

        public AddGatewayCommandTests(TestApplicationFactory<Startup> factory)
        {
            _serviceProvider = factory.Services;
            _messageDispatcher = _serviceProvider.GetService<IMessageDispatcher>();
        }



        [Fact]
        public async Task SaveOneGatewayAsync_ShouldResturnFailure()
        {
            var command = new AddGatewayCommand
            {
                IPV4 = "0,0.1",
                Name = "Gateway3"

            };
            //Act
            var result = await _messageDispatcher.DispatchAsync(command);
            //Assert
            Assert.True(result.IsFailure);


        }


        [Fact]
        public async Task GetGetAllGatewaysQueryAsync_ShouldReturnSuccess()
        {
            var command = new AddGatewayCommand
            {
                IPV4 = "0.0.1.2",
                Name = "Gateway5"

            };

            List<DeviceCommand> devices = new();
            for (int i = 0; i < 10 ; i++)
            {
                var deviceCommand = new DeviceCommand
                {
                    StatusId = 1,
                    Vendor = $"vendor {i}",
                };

                devices.Add(deviceCommand);
            }

            command.Devices.AddRange(devices);

            //Act
            var result = await _messageDispatcher.DispatchAsync(command);
            //Assert
            Assert.True(result.IsSuccess && result.Value.Devices.Count== devices.Count);
        }



        [Fact]
        public async Task GetGetAllGatewaysQueryAsync_ShouldResturnFailure()
        {
            var command = new AddGatewayCommand
            {
                IPV4 = "0.0.1.2",
                Name = "Gateway5"

            };

            List<DeviceCommand> devices = new();
            for (int i = 0; i <11; i++)
            {
                var deviceCommand = new DeviceCommand
                {
                    StatusId = 1,
                    Vendor = $"vendor {i}",
                };

                devices.Add(deviceCommand);
            }

            command.Devices.AddRange(devices);

            //Act
            var result = await _messageDispatcher.DispatchAsync(command);
            //Assert
            Assert.False(result.IsSuccess);
        }

    }
}
