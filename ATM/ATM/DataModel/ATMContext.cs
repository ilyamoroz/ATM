using System.Data.Entity;

namespace ATM.DataModel
{
    public class ATMContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<PINCode> PINCodes { get; set; }

    }
}