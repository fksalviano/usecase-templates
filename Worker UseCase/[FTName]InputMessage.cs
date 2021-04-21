using System;
using Application.UseCases.[FTName].Ports;
using XPInc.Pix.Commons.Maestro.Messages;

namespace Workers.UseCases.Entries.v1.[FTName]
{
    public class [FTName]InputMessage : MessageBase<object>
    {
        public override string ToString()
        {
            return $"Input:{Data!.ToString()}";
        }

        public [FTName]Input To[FTName]Input() =>
            new [FTName]Input(RequestId ?? Guid.Empty);        
    }
}