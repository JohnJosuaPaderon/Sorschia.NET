namespace Sorschia.Processing
{
    public static class ProcessResultMessage
    {
        static ProcessResultMessage()
        {
            ExceptionThrown = "An exception has been thrown.";
            Success = "Process successfully completed.";
            NoResult = "Process successfully completed but has no result.";
        }

        public static string ExceptionThrown { get; }
        public static string Success { get; }
        public static string NoResult { get; }
    }
}
