using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Shared.Infra.Sql;
using Dapper;
using Dapper.Transaction;
using Microsoft.Extensions.Logging;
using Application.UseCases.[FTName].Abstractions;
using Application.UseCases.[FTName].Repositories.Commands;
using Application.UseCases.[FTName].Ports;

namespace Application.UseCases.[FTName].Repositories
{
    public class [FTName]Repository : TransactionBase, I[FTName]Repository
    {
        private readonly ILogger<[FTName]Repository> _logger;

        public [FTName]Repository(
            IConnectionProvider connection, ILogger<[FTName]Repository> logger)
            : base(connection)
        {
            _logger = logger;
        }

        public async Task<bool> [FTName]Async([FTName]Input input, CancellationToken cancellationToken)
        {
            try
            {
                var command = [FTName]Command.GetCommand(input, Transaction, cancellationToken);

                var rowsAffected = await Transaction.ExecuteAsync(command);
                if (rowsAffected == 0)
                {
                    _logger.RecordNotUpdatedAsExpectedExecutingUpdate(input.RequestId);
                    return false;
                }

                _logger.RecordsUpdatedSuccessfully(input.RequestId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.ExceptionWhenTryTo[FTName]OnDatabase(input.RequestId, ex);
                return false;
            }            
        }        
    }
}