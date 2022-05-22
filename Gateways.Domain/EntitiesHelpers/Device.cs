using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Domain.Entities
{
    public sealed partial class Device
    {
        public void SetIsDeleted(bool value) 
        {
            IsDeleted = value;
        }
    }
}
