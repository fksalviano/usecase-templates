using System;
using System.Data;
using System.Threading;
using Application.UseCases.[FTName].Ports;
using Dapper;

namespace Application.UseCases.[FTName].Repositories.Commands
{
    public static class [FTName]Command
    {
        
        public static CommandDefinition GetCommand([FTName]Input input, 
            IDbTransaction transaction, CancellationToken cancellationToken)
        {
            var updateAt  = DateTimeOffset.UtcNow;
            return new CommandDefinition
            (
                CommandText, new
                {

                },
                cancellationToken: cancellationToken,
                transaction : transaction
            );
        }

        private const string CommandText =
            @"
            SELECT * | UPDATE [Owner].[Table] 
            SET                
            WHERE
                Id = @Id";
    }
}