using Gateways.Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Commands.Models
{
    public class DeviceCommand
    {
        public int Id { get; set; } = default;

        public string Vendor { get; set; }

        public int StatusId { get; set; }

        public Guid GatewayId { get; set; } = new ();
    }
}
