using FluentValidation;
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

namespace Gateways.Commands.Validators
{
    public class AddGateWayCommandValidator : AbstractValidator<GatewayCommand>
    {
       
        public AddGateWayCommandValidator()
        {
            When(x => x != null, () =>
            {

                RuleFor(c => c.Name).NotEmpty().NotNull();
                RuleFor(c => c.IPV4).NotNull().NotEmpty().SetValidator(new IPV4AdressValidationRule());

                RuleFor(c => c.Devices.Count).GreaterThanOrEqualTo(0).LessThanOrEqualTo(10).WithMessage("A gateway should have no more than 10 devices");

                When(x =>  x.Devices.Count > 0, () =>
                {
                    RuleForEach(c => c.Devices).ChildRules
                    (
                        command =>
                        {
                            command.RuleFor(c => c.Vendor).NotNull().NotEmpty();
                            command.RuleFor(c => c.StatusId).Must(l=> Enum.IsDefined(typeof(DeviceStatus),l)).WithMessage("invalid status Id");                            
                        }
                    );


                });



            });
        }
    }
}
