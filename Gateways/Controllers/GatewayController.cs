using Gateways.Commands.Commands;
using Gateways.Domain.Shared.Interfaces;
using Gateways.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gateways.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IMessageDispatcher _messageDispatcher;
        public GatewayController(IMessageDispatcher messageDispatcher)
        {
            _messageDispatcher = messageDispatcher;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _messageDispatcher.DispatchAsync(new GetAllGatewaysQuery());

            return Ok(result);

        }


        [HttpGet]
        public async Task<IActionResult> GetGateway(string gatewayId)
        {

            var result = await _messageDispatcher.DispatchAsync(new GetGatewayDetailsByIdQuery(gatewayId));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddGateWay(AddGatewayCommand command)
        {
            var result = await _messageDispatcher.DispatchAsync(command);

            return Ok(result);
        }
    }
}
