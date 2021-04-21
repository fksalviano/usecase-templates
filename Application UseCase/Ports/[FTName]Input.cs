using System;

namespace Application.UseCases.[FTName].Ports
{
    public class [FTName]Input
    {
        public Guid RequestId { get; set; }

        public [FTName]Input(Guid requestId)
        {
            RequestId = requestId;
        }

    }
}