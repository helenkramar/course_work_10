using System.Data.Entity;

namespace DAL.EF
{
    public class CafeInitializer : DropCreateDatabaseAlways<CafeContext>
    {
        protected override void Seed(CafeContext db)
        {
            db.SaveChanges();
        }
    }
}
