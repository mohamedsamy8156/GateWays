
using Gateways.Commands.Models;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using System.Threading.Tasks;
using System.Threading;
using Gateways.Domain.Repositories;
using CSharpFunctionalExtensions;
using System;

namespace Gateways.Commands.Validator.ValidationRules
{
    public class MaximumGatewayDevicesValidtor : AsyncPropertyValidator<DeviceCommand, Guid>
    {
        public override string Name => "MaxiumGateWayValidator";

        private readonly IDeviceQueryRepository _deviceQueryRepository;

        public MaximumGatewayDevicesValidtor(IDeviceQueryRepository deviceQueryRepository)
        {
            _deviceQueryRepository = deviceQueryRepository;
        }

        public override async Task<bool> IsValidAsync(ValidationContext<DeviceCommand> context, Guid value, CancellationToken cancellation)
        {
            var deviceCommand = context.InstanceToValidate;

            var result = await _deviceQueryRepository.GetAllDeviceByGatewayId(deviceCommand.GatewayId.ToString());
            context.AddFailure(new ValidationFailure("Gateway", $"This gateway has the maximum devices"));

            return result.IsSuccess && result.Value.Count <= 10;

        }
    }
}
