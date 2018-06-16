using System.Data.Entity;

namespace DAL.EF
{
    public class PositionInitializer : DropCreateDatabaseIfModelChanges<PositionContext>
    {
        protected override void Seed(PositionContext db)
        {
            //db.SaveChanges();
        }
    }
}
