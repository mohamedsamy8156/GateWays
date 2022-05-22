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

namespace Gateways.Infrastructure.Repositories.Queries
{
    public class DeviceQueryRepository : IDeviceQueryRepository
    {
        public readonly GatewayDbContext _dbContext;

        public DeviceQueryRepository(GatewayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Result<List<Device>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<Device>>> GetAllDeviceByGatewayId(string Id)
        {
            try
            {
                return await Result.Success().Bind(async () =>
                {
                    var result = await _dbContext.Devices.Where(l => l.GatewayId.ToString() == Id && !l.IsDeleted).ToListAsync();
                    return Result.Success(result);

                }).OnFailure(error => throw new Exception(error));

            }
            catch (Exception ex)
            {
                return Result.Failure<List<Device>>(ex.Message);
            }

        }

        public async Task<Result<Device>> GetDeviceByIdAsync(long Id)
        {
            return await _dbContext.Devices.FirstOrDefaultAsync(l => l.Id == Id && !l.IsDeleted);
        }
    }
}
