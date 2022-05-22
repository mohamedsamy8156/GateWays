using CSharpFunctionalExtensions;
using Gateways.Commands.Commands;
using Gateways.Commands.Models;
using Gateways.Domain.Shared.Interfaces;
using Gateways.Service.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateways.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IMessageDispatcher _messageDispatcher;
        public DevicesController(IMessageDispatcher messageDispatcher)
        {
            _messageDispatcher = messageDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string gatewayId)
        {
            var result = await _messageDispatcher.DispatchAsync(new GetGatewayDetailsByIdQuery(gatewayId));

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddDeviceCommand command)
        {
            var result = await _messageDispatcher.DispatchAsync(command);

            return Ok(result);
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(long deviceId)
        {
            var result = await _messageDispatcher.DispatchAsync(new DeleteDeviceCommand { Id = deviceId });

            return Ok(result);
        }


    }
}
