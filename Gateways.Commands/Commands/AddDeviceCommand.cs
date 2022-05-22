using AutoMapper;
using CSharpFunctionalExtensions;
using Gateways.Commands.Models;
using Gateways.Commands.Validator;
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
    public class AddDeviceCommand : DeviceCommand, ICommand<DeviceModel>
    {


    }


    public class SaveDeviceCommandHandler : ICommandHandler<AddDeviceCommand, DeviceModel>
    {

        private readonly IDeviceQueryRepository _deviceQueryRepository;
        private readonly IMapper _mapper;
        private readonly IDeviceCommandRepository _deviceCommandRepository;
        private readonly IGatewayQueryRepository _gatewayQueryRepository;


        public SaveDeviceCommandHandler(IDeviceQueryRepository deviceQueryRepository, IMapper mapper, IDeviceCommandRepository deviceCommandRepository,
            IGatewayQueryRepository gatewayQueryRepository)
        {
            _deviceQueryRepository = deviceQueryRepository;
            _mapper = mapper;
            _deviceCommandRepository = deviceCommandRepository;
            _gatewayQueryRepository = gatewayQueryRepository;
        }

        public async Task<Result<DeviceModel>> HandleAsync(AddDeviceCommand command)
        {
            try
            {

                var validator = new AddDeviceCommandValidator(_deviceQueryRepository, _gatewayQueryRepository);
                var commandalidationResult = await validator.ValidateAsync(command);

                if (commandalidationResult.IsValid)
                {

                    return await Result.Success().Bind(async () =>
                    {
                        var deviceEntity = _mapper.Map<Device>(command);
                        var resultEntity = await _deviceCommandRepository.AddDevice(deviceEntity);


                        return Result.Success(_mapper.Map<DeviceModel>(resultEntity.Value));
                    }).OnFailure(error => throw new Exception(error));


                }

                return Result.Failure<DeviceModel>(string.Join (",",commandalidationResult));

            }
            catch (Exception exception)
            {
                return Result.Failure<DeviceModel>(exception.Message);
            }



        }
    }
}

