using System.Collections.Generic;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class MetaInitializer : DropCreateDatabaseAlways<MetaContext>
    {
        protected override void Seed(MetaContext db)
        {
            ConnectionDetails conDet1 = new ConnectionDetails { Id = 1, DatabaseName = @"\cafedb.mdf", Host = @"(localdb)\MSSQLLocalDB", IntegratedSecurity = true };
            ConnectionDetails conDet2 = new ConnectionDetails { Id = 2, DatabaseName = @"\manufacturedb.mdf", Host = @"(localdb)\MSSQLLocalDB", IntegratedSecurity = true };

            List<ConnectionDetails> conDetList = new List<ConnectionDetails> { conDet1, conDet2 };
            db.ConnectionDetails.AddRange(conDetList);

            DataBase cafe = new DataBase
            {
                Name = "CafeDataBase",
                DatabaseInfo = "cafe 1 info",
                ConnectionDetails = conDet1
            };
            DataBase manufacture = new DataBase
            {
                Name = "ManufactureDataBase",
                DatabaseInfo = "manufacture info",
                ConnectionDetails = conDet2
            };

            List<DataBase> dataBaseList = new List<DataBase> { cafe, manufacture };
            db.DataBases.AddRange(dataBaseList);
            db.SaveChanges();
        }
    }
}