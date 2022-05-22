using Gateways.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Infrastructure.Persistence.Configurations
{
    internal class GatewayConfiguration : IEntityTypeConfiguration<Gateway>
    {
        public void Configure(EntityTypeBuilder<Gateway> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();


            builder.Property(c=>c.IPV4).IsRequired();

            builder.Property(c => c.Name).IsRequired();

            builder.Property<DateTime>("CreatedOn").IsRequired();



            var getwaysDevicesNavigation = builder.Metadata.FindNavigation(nameof(Gateway.Devices));
            if (getwaysDevicesNavigation != null)
            {
                getwaysDevicesNavigation.SetField("_devices");
                getwaysDevicesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            }

        }
    }
}
