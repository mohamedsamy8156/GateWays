using Gateways.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Infrastructure.Persistence
{
   public class GatewayDbContext: DbContext
   {

        public GatewayDbContext(DbContextOptions<GatewayDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet <Gateway> Gateways { get; set; }

        public DbSet<Device> Devices { get; set; }
    }
}
