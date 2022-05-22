using Gateways.Domain.Repositories;
using Gateways.Infrastructure.Persistence;
using Gateways.Infrastructure.Repositories.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using Gateways.Domain.Shared.Interfaces;
using Gateways.Commands.Commands;
using Gateways.Domain.DataModels;
using Gateways.Service.Queries;
using Gateways.Infrastructure.Repositories.Queries;
using Gateways.Commands.Models;
using FluentValidation;
using Gateways.Commands.Validator;
using Gateways.Commands.Validators;
using Gateways.Service.Shared.Helpers;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Gateways.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton(services);

            services.AddDbContext<GatewayDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));



            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddControllers()
              .AddNewtonsoftJson(options =>
              {
                  options.SerializerSettings.Formatting = Formatting.Indented;
                  //options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                  //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                  options.SerializerSettings.ContractResolver = new DefaultContractResolver
                  {
                      NamingStrategy = new DefaultNamingStrategy()
                  };
              })
              .AddFluentValidation(c =>
              {
                  c.AutomaticValidationEnabled = false;
              });


            #region validators
            services.AddTransient<IValidator<DeviceCommand>, AddDeviceCommandValidator>();
            services.AddTransient<IValidator<GatewayCommand>, AddGateWayCommandValidator>();
            #endregion

            services.AddScoped<IMessageDispatcher, Dispatcher>();


            #region Repositories

            services.AddTransient<IDeviceCommandRepository, DeviceCommandRepository>();
            services.AddTransient<IGatewayCommandRepository, GatewayCommandRepository>();

            services.AddTransient<IDeviceQueryRepository, DeviceQueryRepository>();
            services.AddTransient<IGatewayQueryRepository, GatewayQueryRepository>();

            #endregion



            #region Handlers

            services.TryAddTransient(typeof(IQueryHandler<GetAllGatewaysQuery, List<GatewayModel>>), typeof(GetAllGatewaysQueryHandler));
            services.TryAddTransient(typeof(IQueryHandler<GetGatewayDetailsByIdQuery, GatewayModel>), typeof(GetGatewayDetailsByIdQueryHandler));
            services.TryAddTransient(typeof(ICommandHandler<AddDeviceCommand, DeviceModel>), typeof(SaveDeviceCommandHandler));
            services.TryAddTransient(typeof(ICommandHandler<AddGatewayCommand, GatewayModel>), typeof(AddGatewayCommandHandler));
            services.TryAddTransient(typeof(ICommandHandler<DeleteDeviceCommand, bool>), typeof(DeleteDeviceCommandHandler));

            #endregion




            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gateways", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gateways v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
