using FluentValidation;
using Gateways.Commands.Commands;
using Gateways.Commands.Models;
using Gateways.Commands.ValidationRules;
using Gateways.Commands.Validator.ValidationRules;
using Gateways.Domain.Enums;
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
        public AddDeviceCommandValidator(IDeviceQueryRepository deviceQueryRepository , IGatewayQueryRepository gatewayQueryRepository)
        {

            When(x => x != null, () =>
            {
                RuleFor(c => c.Vendor).NotNull().NotEmpty().WithMessage("please enter a vendor");
                RuleFor(c => c.StatusId).Must(x=> Enum.IsDefined(typeof(DeviceStatus),x)).WithMessage("status is not valid");
                RuleFor(c => c.GatewayId).NotEmpty().NotNull().WithMessage("please enter valid gateway");
                RuleFor(c => c.GatewayId).SetAsyncValidator(new CheckGatewayIfExisitsValidator(gatewayQueryRepository));
                RuleFor(c => c.GatewayId).SetAsyncValidator(new MaximumGatewayDevicesValidtor(deviceQueryRepository));


            });
        }


    }
}
