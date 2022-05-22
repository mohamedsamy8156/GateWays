using CSharpFunctionalExtensions;
using Gateways.Domain.Repositories;
using Gateways.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Commands.Commands
{
    public class DeleteDeviceCommand : ICommand<bool>
    {
        public long Id;
    }


    public class DeleteDeviceCommandHandler : ICommandHandler<DeleteDeviceCommand, bool>
    {

        private readonly IDeviceCommandRepository _deviceCommandRepository;
        private readonly IDeviceQueryRepository _queryRepository;


        public DeleteDeviceCommandHandler(IDeviceCommandRepository deviceCommandRepository, IDeviceQueryRepository deviceQueryRepository) 
        {
            _deviceCommandRepository = deviceCommandRepository;
            _queryRepository = deviceQueryRepository;
        }
        public async Task<Result<bool>> HandleAsync(DeleteDeviceCommand command)
        {

            try
            {
                if (command.Id > 0)
                {
                    var result = await _queryRepository.GetDeviceByIdAsync(command.Id).TapIf(entity => entity != null, async () =>
                    {

                        await _deviceCommandRepository.DeleteDeviceAsync(command.Id);

                    }).OnFailure(err => throw new Exception(err));

                    return result.IsSuccess;
                }

                else
                {
                    return Result.Failure<bool>($"No Device with Id = {command.Id}");
                }

            }
            catch (Exception ex)
            {

                return Result.Failure<bool>(ex.Message);

            }

        }
    }
}
