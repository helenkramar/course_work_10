using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class PositionContext : DbContext
    {
        public DbSet<Position> Positions { get; set; }

        //static PositionContext()
        //{
        //    System.Data.Entity.DataBase.SetInitializer<PositionContext>(new PositionInitializer());
        //}

        public PositionContext(string connectionString) : base(connectionString)
        { }
    }
}