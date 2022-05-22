using AutoMapper;
using Gateways.Commands.Models;
using Gateways.Domain.DataModels;
using Gateways.Domain.Entities;
using Gateways.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Service.Mappers
{
    public class GatewayProfile : Profile
    {
        public GatewayProfile()
        {
            CreateMap<GatewayCommand, Gateway>()
            .ForMember(c => c.CreatedOn, op => op.MapFrom(c => DateTime.Now))
            .ForMember(c => c.Id, opt => opt.MapFrom(c => Guid.Empty));


            CreateMap<Gateway, GatewayModel>();

            CreateMap<DeviceCommand, Device>()
             .ForMember(c => c.CreatedOn, op => op.MapFrom(c => DateTime.Now));

            CreateMap<Device, DeviceModel>();

        }
    }
}
