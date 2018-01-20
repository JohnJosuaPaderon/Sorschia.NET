namespace Sorschia
{
    internal static class LibraryResources
    {
        static LibraryResources()
        {
            DefaultConnectionStringKey = "dbo";
            DefaultSchema = "dbo";
        }

        public static string DefaultConnectionStringKey { get; }
        public static string DefaultSchema { get; }
    }
}
