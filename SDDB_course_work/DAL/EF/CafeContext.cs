using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class CafeContext : DbContext
    {
        public DbSet<Position> Positions { get; set; }

        static CafeContext()
        {
            System.Data.Entity.Database.SetInitializer<CafeContext>(new CafeInitializer());
        }

        public CafeContext(string connectionString) : base(connectionString)
        { }
    }
}