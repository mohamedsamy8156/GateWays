using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using Gateways.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gateways.Commands.ValidationRules
{
    public class IPV4AdressValidationRule : PropertyValidator<GatewayCommand, string>
    {


        public override string Name => "IPV4 Validator";


        public IPV4AdressValidationRule()
        {
        }

        public override bool IsValid(ValidationContext<GatewayCommand> context, string value)
        {
            var gatewayCommand = context.InstanceToValidate;

            var result = ValidateIPv4(gatewayCommand.IPV4);
            if (!result)
                context.AddFailure(new ValidationFailure("IPV4", $"IPV4 address not valid"));


            return result;


            // local function 
            static bool ValidateIPv4(string ipString)
            {

                string[] splitValues = ipString.Split('.');
                if (splitValues.Length != 4)
                {
                    return false;
                }

                byte tempForParsing;

                return splitValues.All(r => byte.TryParse(r, out tempForParsing));
            }

        }


    }
}
