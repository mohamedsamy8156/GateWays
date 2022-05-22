using CSharpFunctionalExtensions;
using Gateways.Domain.Shared.Interfaces;
using Gateways.Service.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Service.Shared.Helpers
{
    public class Dispatcher : IMessageDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<Result<T>> DispatchAsync<T>(ICommand<T> command)
        {
            try
            {
                var commandType = command.GetType();

                var type = typeof(ICommandHandler<,>).MakeGenericType(commandType, typeof(T));
               //ar handlerType = type.MakeGenericType();
                dynamic handler = _serviceProvider.GetService(type);
                if (handler != null)
                {
                    return await handler.HandleAsync((dynamic)command);
                }
                return Result.Failure<T>("handler is null");
            }
            catch (Exception exception)
            {
                return Result.Failure<T>(exception.Message);
            }
        }

        public async Task<Result<T>> DispatchAsync<T>(IQuery<T> query)
        {
            try
            {
                var queryType = query.GetType();
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(T));
                dynamic  handler = _serviceProvider.GetService(handlerType);
                if (handler != null)
                {
                    return await handler.HandleAsync((dynamic)query);
                }
                return Result.Failure<T>("DispatchAsync Handler not registered for type " + queryType.Name);
            }
            catch (Exception exception)
            {
                return Result.Failure<T>(exception.Message);
            }
        }
    }
}
