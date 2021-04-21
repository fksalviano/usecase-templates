namespace Workers.UseCases.Entries.v1.[FTName]
{
    public class [FTName]OutputMessage
    {
        public static [FTName]OutputMessage ExecutedSuccess =>
            new [FTName]OutputMessage(true);

        public static [FTName]OutputMessage ExecutedError =>
            new [FTName]OutputMessage(false);

        private [FTName]OutputMessage(bool success) => Success = success;

        public bool Success { get; }
    }
}