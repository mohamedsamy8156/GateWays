using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Domain.Entities
{
    public sealed partial class Device: Entity<long>
    {

        public Device(long id, string vendor, int statusId, Guid gatewayId)
        {
            Id = id;
            StatusId = statusId;
            GatewayId = gatewayId;
            Vendor = vendor;
        }

        public int StatusId { get; private set; }

        public string Vendor { get; set; }

        public Guid GatewayId { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public bool IsDeleted { get; private set; }


    }
}
