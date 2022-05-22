using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using Gateways.Commands.Models;
using Gateways.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gateways.Commands.ValidationRules
{
    public class CheckGatewayIfExisitsValidator : AsyncPropertyValidator<DeviceCommand, Guid>
    {

        private readonly IGatewayQueryRepository _gatewayQueryRepository;

        public override string Name => "CheckGatewayIfExisitsValidator";

        public CheckGatewayIfExisitsValidator(IGatewayQueryRepository gatewayQueryRepository)
        {
            _gatewayQueryRepository = gatewayQueryRepository;
        }

        public override async Task<bool> IsValidAsync(ValidationContext<DeviceCommand> context, Guid value, CancellationToken cancellation)
        {
            var deviceCommand = context.InstanceToValidate;

            var result = await _gatewayQueryRepository.GetGatewayById(deviceCommand.GatewayId.ToString());
            if(result.IsFailure)
            context.AddFailure(new ValidationFailure("Gateway", $"This gateway is not exisit"));

            return result.IsSuccess && result.Value != null;


        }
    }
}
