using CSharpFunctionalExtensions;
using Gateways.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Domain.Repositories
{
    public interface IGatewayQueryRepository
    {
        Task<Result<List<Gateway>>> GetAll();

        Task<Result<Gateway>> GetGatewayById(string Id);

    }
}
