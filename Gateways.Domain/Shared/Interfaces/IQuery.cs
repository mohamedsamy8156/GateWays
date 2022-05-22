using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Gateways.Domain.Shared.Interfaces
{
    public interface IQuery<TResult>
    {

    }

    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<Result<TResult>> HandleAsync(TQuery query);
    }

}
