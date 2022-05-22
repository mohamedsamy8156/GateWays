using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Domain.DataModels
{
    public class DeviceModel
    {
        public long Id { get; set; }

        public string Vendor { get;  set; }

        public int StatusId { get;  set; }

        public Guid GatewayId { get;  set; }

        public bool IsDeleted { get;  set; }


    }
}
