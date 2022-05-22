using Gateways.Domain.Shared.Interfaces;
using Gateways.Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Commands.Models
{
    public class GatewayCommand
    {

        public Guid? Id { get; private set; } = Guid.Empty;

        public string Name { get; set; }

        public string IPV4 { get; set; }

        public string Description { get; set; }


        public List<DeviceCommand> Devices { get; set; } = new();



    }
}
