using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Domain.Entities
{
    public sealed partial class Gateway
    {
        public void SetDevices(List<Device> devices ) 
        {
            _devices.AddRange(devices);
        }

        public void Set(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
    }
}
