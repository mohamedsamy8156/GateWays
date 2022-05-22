using AutoMapper;
using CSharpFunctionalExtensions;
using Gateways.Domain.DataModels;
using Gateways.Domain.Repositories;
using Gateways.Domain.Shared.Interfaces;
using Gateways.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Service.Queries
{
    public class GetAllGatewaysQuery : IQuery<List<GatewayModel>>
    {

        public GetAllGatewaysQuery() { }
    }



    public class GetAllGatewaysQueryHandler : IQueryHandler<GetAllGatewaysQuery,List<GatewayModel>>
    {

        private readonly IGatewayQueryRepository _gatewayQueryRepository;
        private readonly IMapper _mapper;

        public GetAllGatewaysQueryHandler(IGatewayQueryRepository gatewayQueryRepository,
        IMapper mapper)
        {
            _gatewayQueryRepository = gatewayQueryRepository;
            _mapper = mapper;
        }
        public async Task<Result<List<GatewayModel>>> HandleAsync(GetAllGatewaysQuery query)
        {
            try
            {
                //ToDo ===> Paging

                var result = await _gatewayQueryRepository.GetAll()
                                         .Bind((gateways) =>
                                         {
                                             var mappedGateways = _mapper.Map<List<GatewayModel>>(gateways);
                                             return Result.Success(mappedGateways);
                                         });
                return result;
            }
            catch (Exception exception)
            {
                return Result.Failure<List<GatewayModel>>(exception.Message);
            }
        }
    }
}

