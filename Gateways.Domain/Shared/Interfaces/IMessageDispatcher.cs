using CSharpFunctionalExtensions;
using Gateways.Domain.Shared.Interfaces;
using System.Threading.Tasks;

namespace Gateways.Domain.Shared.Interfaces
{
    public interface IMessageDispatcher
    {
        Task<Result<T>> DispatchAsync<T>(ICommand<T> command);

        Task<Result<T>> DispatchAsync<T>(IQuery<T> query);

    }
}