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
    internal class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.StatusId).IsRequired();

            builder.Property(c => c.GatewayId).IsRequired();

            builder.Property(c => c.Vendor).IsRequired();



            builder.Property<DateTime>("CreatedOn").IsRequired();
        }
    }
}
