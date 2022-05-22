using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Domain.DataModels
{
    public class GatewayModel
    {
        public Guid Id { get; set; }

        public string Name { get;  set; }

        public string IPV4 { get;  set; }

        public List<DeviceModel> Devices { get; set; }
    }


    public class GatewaysModel
    {
        List<GatewayModel> Gateways { get; set; }

    }
}
