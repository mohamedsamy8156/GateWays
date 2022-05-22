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
    public sealed class GetGatewayDetailsByIdQuery: IQuery<GatewayModel>
    {

        public string GatewayId { get; set; }
        public GetGatewayDetailsByIdQuery(string gatewayId) 
        {
            GatewayId = gatewayId;
        }
    }


    public class GetGatewayDetailsByIdQueryHandler : IQueryHandler<GetGatewayDetailsByIdQuery, GatewayModel>
    {
        private readonly IGatewayQueryRepository _gatewayQueryRepository;
        private readonly IMapper _mapper;

        public GetGatewayDetailsByIdQueryHandler(IGatewayQueryRepository gatewayQueryRepository,
        IMapper mapper)
        {
            _gatewayQueryRepository = gatewayQueryRepository;
            _mapper = mapper;
        }
        public async Task<Result<GatewayModel>> HandleAsync(GetGatewayDetailsByIdQuery query)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(query.GatewayId)) 
                {

                    var result = await _gatewayQueryRepository.GetGatewayById(query.GatewayId)
                                         .Bind((gateway) =>
                                         {
                                             var mappedGateway = _mapper.Map<GatewayModel>(gateway);
                                             return Result.Success(mappedGateway);
                                         });
                    return result;
                }

                else 
                {
                    return Result.Failure<GatewayModel>("Please enter a valid Id");
                }
                
            }
            catch (Exception exception)
            {
                return Result.Failure<GatewayModel>(exception.Message);
            }
        }
    }


}
