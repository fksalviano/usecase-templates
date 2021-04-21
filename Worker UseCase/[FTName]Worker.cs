using System.Threading;
using System.Threading.Tasks;
using Application.UseCases.[FTName].Abstractions;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using SerilogTimings;
using XPInc.Maestro.Abstractions.Messages;
using XPInc.Maestro.Runner.Abstractions;
using XPInc.Pix.Commons.Domains.Enums;
using XPInc.Pix.Commons.Domains.Exceptions;
using XPInc.Pix.Commons.Domains.Messages;

namespace Workers.UseCases.Entries.v1.[FTName]
{
    public class [FTName]Worker :
        ChoreographedBackgroundService<[FTName]InputMessage, [FTName]OutputMessage>
    {
        private readonly ILogger<ChoreographedBackgroundService<[FTName]InputMessage, [FTName]OutputMessage>> _logger;
        private readonly I[FTName]UseCase _useCase;

        public override string Mailbox => "dict-key-<FTName | paramcase>";

        private const string SuccessMessage = "[FTName] executed succefully.";
        private const string ErrorMessage = "An error occurred while trying to [FTName].";

        public [FTName]Worker(
            ILogger<ChoreographedBackgroundService<[FTName]InputMessage, [FTName]OutputMessage>> logger, 
            I[FTName]UseCase useCase)
            : base(logger)
        {
            _logger = logger;
            _useCase = useCase;
        }

        public override async Task<[FTName]OutputMessage> ExecuteAsync(
            [FTName]InputMessage input, 
            INotification notification, 
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(LogMessageTemplate.Worker, Mailbox, input.ToString());

            using (LogContext.PushProperty("CorrelationId", input.RequestId.ToString()))
            using (Operation.Time(LogMessageTemplate.Worker, Mailbox, input.ToString()))
            {
                var <FTName | camelcase>Input  = input.To[FTName]Input();
                var <FTName | camelcase>Result = await _useCase.ExecuteAsync(<FTName | camelcase>Input, cancellationToken);
                if (<FTName | camelcase>Result.HasErrors)
                {
                    throw new WorkerException(ErrorMessage);
                }
            
                _logger.LogInformation(SuccessMessage);
                return [FTName]OutputMessage.ExecutedSuccess;
            }
        }        
    }
}