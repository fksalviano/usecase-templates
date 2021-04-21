using System.Threading;
using System.Threading.Tasks;
using Application.Shared;
using Application.UseCases.[FTName].Ports;

namespace Application.UseCases.[FTName].Abstractions
{
    public interface I[FTName]UseCase
    {
        Task<IUseCaseResult<[FTName]Output>> ExecuteAsync(
            [FTName]Input input, CancellationToken cancellationToken);
    }
}