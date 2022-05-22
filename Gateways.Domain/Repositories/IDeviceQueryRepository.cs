using CSharpFunctionalExtensions;
using Gateways.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Domain.Repositories
{
    public interface IDeviceQueryRepository
    {
        Task<Result<List<Device>>> GetAll();

        Task<Result<Device>> GetDeviceByIdAsync(long Id);

        Task<Result<List<Device>>> GetAllDeviceByGatewayId(string Id);


    }
}
