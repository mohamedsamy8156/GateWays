using FluentValidation;
using Gateways.Commands.Commands;
using Gateways.Commands.Models;
using Gateways.Commands.Validator.ValidationRules;
using Gateways.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Commands.Validator
{
    public class AddDeviceCommandValidator : AbstractValidator<DeviceCommand>
    {
        public AddDeviceCommandValidator(IDeviceQueryRepository gatewayQueryRepository)
        {

            When(x => x != null, () =>
            {
                RuleFor(c => c.Vendor).NotNull().NotEmpty();
                RuleFor(c => c.StatusId).GreaterThan(0);
                RuleFor(c => c.GatewayId).NotEmpty().NotNull();
                RuleFor(c => c.GatewayId).SetAsyncValidator(new MaximumGatewayDevicesValidtor(gatewayQueryRepository));

            });
        }


    }
}
