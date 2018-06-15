using System.Collections.Generic;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class ManufactureInitializer : DropCreateDatabaseAlways<ManufactureContext>
    {
        protected override void Seed(ManufactureContext db)
        {
            Position first = new Position {Name = "cake", Amount = 4, Cost = 2.3};
            Position second = new Position { Name = "cookie", Amount = 14, Cost = 3.5};
            Position third = new Position { Name = "candy", Amount = 40, Cost = 2.7};

            List<Position> listPosition = new List<Position> { first, second, third};
            db.Positions.AddRange(listPosition);

            db.SaveChanges();
        }
    }
}