using AutoMapper;
using CSharpFunctionalExtensions;
using Gateways.Commands.Models;
using Gateways.Commands.Validator;
using Gateways.Commands.Validators;
using Gateways.Domain.DataModels;
using Gateways.Domain.Entities;
using Gateways.Domain.Repositories;
using Gateways.Domain.Shared.Interfaces;
using Gateways.Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Commands.Commands
{
    public class AddGatewayCommand : GatewayCommand,ICommand<GatewayModel>
    {


    }

    public class AddGatewayCommandHandler : ICommandHandler<AddGatewayCommand, GatewayModel>
    {

        private readonly IMapper _mapper;
        private readonly IGatewayCommandRepository _gatewayCommandRepository;
        private readonly IDeviceQueryRepository _deviceQueryRepository;


        public AddGatewayCommandHandler(IMapper mapper, IGatewayCommandRepository 
            gatewayCommandRepository, IDeviceQueryRepository deviceQueryRepository)
        {
            _mapper = mapper;
            _gatewayCommandRepository = gatewayCommandRepository;
            _deviceQueryRepository = deviceQueryRepository;

        }
        public async Task<Result<GatewayModel>> HandleAsync(AddGatewayCommand command)
        {
            try
            {
                var validator = new AddGateWayCommandValidator();
                var commandvalidationResult =  validator.Validate(command);
                var defaultValidationMessage = "No default error message has been specified";


                if (commandvalidationResult.IsValid)
                {

                    return await Result.Success().Bind(async () =>
                    {
                        var gatewayEntity = _mapper.Map<Gateway>(command);
                        var resultEntity = await _gatewayCommandRepository.AddGateway(gatewayEntity);


                        return Result.Success(_mapper.Map<GatewayModel>(resultEntity.Value));
                    }).OnFailure(error => throw new Exception(error));

                }

                return Result.Failure<GatewayModel>(string.Join(',', commandvalidationResult.Errors.Where(l=>!l.ErrorMessage.Equals(defaultValidationMessage))));

            }
            catch (Exception exception)
            {
                return Result.Failure<GatewayModel>(exception.Message);
            }
        }
    }
}
