using System.Data.Entity;

namespace ATM.DataModel
{
    public class ATMContext : DbContext
    {
        public ATMContext(string connectionString) : base(connectionString)
        {

        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<PINCode> PINCodes { get; set; }
        public DbSet<RemoteCard> RemoteCards { get; set; }

    }
}