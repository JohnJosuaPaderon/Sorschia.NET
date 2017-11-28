namespace Sorschia.Processing
{
    public sealed class DbProcessContext : ProcessContextBase, IProcessContext
    {
        public string ConnectionStringKey { get; set; }
    }
}
