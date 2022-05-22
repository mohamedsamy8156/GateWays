using CSharpFunctionalExtensions;
using Gateways.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Domain.Repositories
{
    public interface IGatewayCommandRepository
    {
        Task<Result<Gateway>> AddGateway(Gateway gateway);

        Task<Result> UpdateGateway(Gateway gateway);

        //Task<Result> DeleteGatway(string Id);

    }
}
