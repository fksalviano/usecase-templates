using Microsoft.Extensions.Logging;
using System;

namespace Application.UseCases.[FTName]
{
    public static class [FTName]LoggerExtensions
    {
        private static readonly Action<ILogger, Guid?, Exception?> _<FTName | camelcase>InTheDatabase = 
            LoggerMessage.Define<Guid?>(
                LogLevel.Information, 1, "[{RequestId}] [FTName] in the database");

        private static readonly Action<ILogger, Guid?, Exception?> _<FTName | camelcase>Successfully = 
            LoggerMessage.Define<Guid?>(LogLevel.Information, 1, "[{RequestId}] [FTName] successfully");

        private static readonly Action<ILogger, Guid?, Exception?> _recordNotUpdatedAsExpectedExecutingUpdate = 
            LoggerMessage.Define<Guid?>(LogLevel.Information, 1, 
                @"[{RequestId}] Error occurred because but no record have been updated"); 

        private static readonly Action<ILogger, Guid?, Exception?> _exceptionWhenTryTo[FTName]OnDatabase = 
            LoggerMessage.Define<Guid?>(
                LogLevel.Error, 1, "[{RequestId}] Exception occurred when try to [FTName] on database");                

        private static readonly Action<ILogger, Guid?, Exception?> _errorOccurredWhenTryTo[FTName]InTheDatabase = 
            LoggerMessage.Define<Guid?>(LogLevel.Information, 1, 
                "[{RequestId}] An error occurred when try to [FTName] in the database");                                      

        private static readonly Action<ILogger, Guid?, Exception?> _recordsUpdatedSuccessfully = 
            LoggerMessage.Define<Guid?>(
                LogLevel.Information, 1, "[{RequestId}] Records was updated successfully");
            

        public static void [FTName]InTheDatabase(this ILogger logger, Guid? requestId) =>
            _<FTName | camelcase>InTheDatabase(logger, requestId, null);

        public static void [FTName]Successfully(this ILogger logger, Guid? requestId) =>
            _<FTName | camelcase>Successfully(logger, requestId, null);            

        public static void RecordNotUpdatedAsExpectedExecutingUpdate(this ILogger logger, Guid? requestId) =>
            _recordNotUpdatedAsExpectedExecutingUpdate(logger, requestId, null);

        public static void ErrorWhenTryTo[FTName]InTheDatabase(this ILogger logger, Guid? requestId) =>
            _errorOccurredWhenTryTo[FTName]InTheDatabase(logger, requestId, null);

        public static void ExceptionWhenTryTo[FTName]OnDatabase(this ILogger logger, Guid? requestId, 
            Exception exception) =>
                _exceptionWhenTryTo[FTName]OnDatabase(logger, requestId, exception);

        public static void RecordsUpdatedSuccessfully(this ILogger logger, Guid? requestId) =>
            _recordsUpdatedSuccessfully(logger, requestId, null);
    }
}
