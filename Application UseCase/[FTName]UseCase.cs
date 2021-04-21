using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Shared;
using Application.UseCases.[FTName].Abstractions;
using Application.UseCases.[FTName].Ports;
using Microsoft.Extensions.Logging;
using XPInc.Pix.Commons.Domains.Messages;

namespace Application.UseCases.[FTName]
{
    public class [FTName]UseCase : I[FTName]UseCase
    {
        private readonly I[FTName]Repository _repository;
        private readonly ILogger<[FTName]UseCase> _logger;
        
        public [FTName]UseCase(I[FTName]Repository repository, ILogger<[FTName]UseCase> logger)
        {
            _logger = logger;            
            _repository = repository;
        }

        public async Task<IUseCaseResult<[FTName]Output>> ExecuteAsync(
            [FTName]Input input, 
            CancellationToken cancellationToken)
        {
            var executedOnDatabase = await [FTName]OnDatabaseAsync(input, cancellationToken);
            if (!executedOnDatabase)
            {
                return ErrorOnDatabase("An error occurred when try to [FTName] on database", input.RequestId);
            }

            return Completed(input);
        }

        private async Task<bool> [FTName]OnDatabaseAsync(
            [FTName]Input input, 
            CancellationToken cancellationToken)
        {
            _logger.[FTName]InTheDatabase(input.RequestId);

            var transactionOpened = await _repository.BeginTran(cancellationToken);
            if (!transactionOpened)
            {
                return false;
            }

            var executed =  await _repository.[FTName]Async(input, cancellationToken);
            if (!executed)
            {
                _repository.Rollback();
                return false;
            }           

            _repository.Commit();
            return true;
        }

        private IUseCaseResult<[FTName]Output> ErrorOnDatabase(string message, Guid requestId)
        {
            _logger.ErrorWhenTryTo[FTName]InTheDatabase(requestId);

            return Error(PixDictErrorCodesMessages.UnavailableDependency, message);
        }

        private IUseCaseResult<[FTName]Output> Completed([FTName]Input input)
        {
            _logger.[FTName]Successfully(input.RequestId);
            
            return Result(input.RequestId, true);
        }

        private static IUseCaseResult<[FTName]Output> Result(Guid requestId, bool success) =>
            UseCaseResult<[FTName]Output>.Result(new [FTName]Output(requestId, success));
            
        private static IUseCaseResult<[FTName]Output> Error(string code, string message) =>
            UseCaseResult<[FTName]Output>.Error(PixDictErrorCodesMessages.UnavailableDependency, message);
    }
}