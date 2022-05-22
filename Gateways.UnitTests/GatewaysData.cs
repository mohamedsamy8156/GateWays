using Gateways.Domain.Entities;
using Gateways.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.UnitTests
{
    public static class GatewaysData
    {
        public static void  SeedingDataAsync(GatewayDbContext dbContext)
        {

            var Gateway1 = new Gateway(Guid.Empty, "gateway1", "0.0.0.1");
            var devices = new List<Device>()
            {

                new Device(0,"Apple",1,Guid.Empty),
                new Device(0,"Xaomi",1,Guid.Empty),
                new Device(0, "Samsung", 1, Guid.Empty),
                new Device(0, "Huwei", 1, Guid.Empty),
                new Device(0, "Oppo", 1, Guid.Empty),
                new Device(0, "Dell", 1, Guid.Empty),
                new Device(0, "Hp", 1, Guid.Empty),


            };

            Gateway1.SetDevices(devices);

             dbContext.SaveChanges();

        }


    }
}

