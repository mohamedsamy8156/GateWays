using CSharpFunctionalExtensions;
using Gateways.Domain.Entities;
using Gateways.Domain.Repositories;
using Gateways.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Infrastructure.Repositories.Commands
{
    public class DeviceCommandRepository : IDeviceCommandRepository
    {

        public readonly GatewayDbContext _dbContext;
        public DeviceCommandRepository(GatewayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<Device>> AddDevice(Device device)
        {
            try
            {
                return await Result.Success().Bind(async () =>
                {
                    var result = await _dbContext.Devices.AddAsync(device);

                    await _dbContext.SaveChangesAsync();

                    return Result.Success(result.Entity);

                }).OnFailure(error => throw new Exception(error));

            }
            catch (Exception ex)
            {
                return Result.Failure<Device>(ex.Message);
            }
        }

        public async Task<Result> DeleteDeviceAsync(long Id)
        {
            try
            {
                return await Result.Success().Bind(async () =>
                {
                    var result = await _dbContext.Devices.FirstOrDefaultAsync(l => l.Id == Id && l.IsDeleted==false);
                    result.SetIsDeleted(true);
                    await _dbContext.SaveChangesAsync();
                    return Result.Success();
                }).OnFailure(error => throw new Exception(error));

            }
            catch (Exception exception)
            {
                return Result.Failure(exception.Message);
            }
        }

        public Task<Result> UpdateDevice(Device device)
        {
            throw new NotImplementedException();
        }
    }
}
