using Library.Storage;

namespace Library.Services
{
    public class DataBaseContextService : DataBaseContext
    {
        private DataBaseContextService() : base() { }

        public static DataBaseContext GetContext()
        {
            if (Context != null) return Context;
            lock (SyncRoot)
            {
                Context ??= new DataBaseContextService();
            }

            return Context;
        }
    }
}