using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Domain.Entities
{
    public sealed partial class Gateway : Entity<Guid>
    {


        public Gateway(Guid id, string name, string iPV4)
        {
            Id = id;
            Name = name;
            IPV4 = iPV4;

            _devices = new List<Device>();

        }
        public string Name { get; private set; }

        public string IPV4 { get; private set; }

        public bool IsDeleted { get; private set; }

        public DateTime CreatedOn { get; private set; }






        // Navigation Properties 
        public ICollection<Device> Devices => _devices;
        private List<Device> _devices;

    }
}
