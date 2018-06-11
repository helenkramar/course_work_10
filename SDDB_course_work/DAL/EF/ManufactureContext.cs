using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class ManufactureContext : DbContext
    {
        public DbSet<Position> Positions { get; set; }

        static ManufactureContext()
        {
            Database.SetInitializer<ManufactureContext>(new ManufactureInitializer());
        }

        public ManufactureContext(string connectionString) : base(connectionString)
        { }
    }
}
