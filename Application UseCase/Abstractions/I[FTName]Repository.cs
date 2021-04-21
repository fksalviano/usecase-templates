using System.Threading;
using System.Threading.Tasks;
using Application.Shared.Infra.Sql;
using Application.UseCases.[FTName].Ports;

namespace Application.UseCases.[FTName].Abstractions
{
    public interface I[FTName]Repository: ITransactionBase
    {
        Task<bool> [FTName]Async([FTName]Input input, CancellationToken cancellationToken);
    }
}