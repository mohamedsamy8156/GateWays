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
    public class GatewayCommandRepository : IGatewayCommandRepository
    {
        public readonly GatewayDbContext _dbContext;
        public GatewayCommandRepository(GatewayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<Gateway>> AddGateway(Gateway gateway)
        {
            try
            {
                return await Result.Success().Bind(async () =>
                {
                    var result = await _dbContext.Gateways.AddAsync(gateway);                     

                    await _dbContext.SaveChangesAsync();

                    return Result.Success(result.Entity);

                }).OnFailure(error => throw new Exception(error));

            }
            catch (Exception ex)
            {
                return Result.Failure<Gateway>(ex.Message);
            }

        }

       

        public async Task<Result> UpdateGateway(Gateway gateway)
        {
            try
            {
                return await Result.Success().Bind(async () =>
                {
                    var result = await _dbContext.Gateways.FirstOrDefaultAsync(l => l.Id == gateway.Id);
                    if (result == null)
                        return Result.Failure("Not exsist Gateway");


                    await _dbContext.SaveChangesAsync();
                    return Result.Success(result);
                }).OnFailure(error => throw new Exception(error));

            }
            catch (Exception exception)
            {
                return Result.Failure(exception.Message);
            }
        }
    }
}
