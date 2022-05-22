using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Gateways.Domain.Shared.Interfaces
{
    public interface ICommand<TResult>
    {

    }


    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<Result<TResult>> HandleAsync(TCommand command);
    }

}
