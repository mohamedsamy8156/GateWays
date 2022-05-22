using CSharpFunctionalExtensions;
using Gateways.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Domain.Repositories
{
    public interface IDeviceCommandRepository
    {
        Task<Result<Device>> AddDevice(Device device);

        Task<Result> UpdateDevice(Device device);

        Task<Result> DeleteDeviceAsync(long Id);

    }
}
