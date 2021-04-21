using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Shared;
using Application.UseCases.[FTName].Abstractions;
using Application.UseCases.[FTName].Ports;
using XPInc.Pix.Commons.Domains.Messages;

namespace Application.UseCases.[FTName]
{
    public class [FTName]ValidationUseCase : I[FTName]UseCase
    {
        private readonly I[FTName]UseCase _useCase;
        public [FTName]ValidationUseCase(I[FTName]UseCase useCase) =>
            _useCase = useCase;
            
        private static IUseCaseResult<[FTName]Output> ValidationError( string message) => 
            UseCaseResult<[FTName]Output>.Error(PixDictErrorCodesMessages.ValidationError, message);

        public async Task<IUseCaseResult<[FTName]Output>> ExecuteAsync(
            [FTName]Input input, CancellationToken cancellationToken)
        {
            if (input.RequestId == Guid.Empty)
            {
                return ValidationError($"{nameof(input.RequestId)} is empty");
            }

            return await _useCase.ExecuteAsync(input, cancellationToken);
        }
    }
}