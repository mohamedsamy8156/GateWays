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
    public class GatewayQueryRepository : IGatewayQueryRepository
    {

        public readonly GatewayDbContext _dbContext;

        public GatewayQueryRepository(GatewayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<List<Gateway>>> GetAll()
        {
            return await _dbContext.Gateways.Include(l => l.Devices).ToListAsync();
        }

        public async Task<Result<Gateway>> GetGatewayById(string Id)
        {

            try
            {
                var result = await Result.Success().Bind(async () =>
                {
                    var entityFromDb= await _dbContext.Gateways.Include(l => l.Devices)
                         .FirstOrDefaultAsync(l => l.Id.ToString() == Id);
                    return Result.Success(entityFromDb);

                }).OnFailure(error => throw new Exception(error));

                return result;
            }
            catch (Exception ex)
            {
                return Result.Failure<Gateway>(ex.Message);
            }
        }
    }
}
