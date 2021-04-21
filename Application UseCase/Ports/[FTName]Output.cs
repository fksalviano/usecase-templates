using System;

namespace Application.UseCases.[FTName].Ports
{
    public class [FTName]Output
    {
        public Guid RequestId { get; set; }
        public bool Success { get; set; }

        public [FTName]Output(Guid requestId, bool success)
        {
            Success = success;
            RequestId = requestId;
        }
    }
}