using System.Collections.Generic;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class MetaInitializer : DropCreateDatabaseAlways<MetaContext>
    {
        protected override void Seed(MetaContext db)
        {
            ConnectionDetails conDet1 = new ConnectionDetails { Id = 1, DatabaseName = @"\cafe1db.mdf", Host = @"(localdb)\MSSQLLocalDB", IntegratedSecurity = true };
            ConnectionDetails conDet2 = new ConnectionDetails { Id = 2, DatabaseName = @"\cafe2db.mdf", Host = @"(localdb)\MSSQLLocalDB", IntegratedSecurity = true };
            ConnectionDetails conDet3 = new ConnectionDetails { Id = 3, DatabaseName = @"\manufacturedb.mdf", Host = @"(localdb)\MSSQLLocalDB", IntegratedSecurity = true };

            List<ConnectionDetails> conDetList = new List<ConnectionDetails> { conDet1, conDet2 , conDet3};
            db.ConnectionDetails.AddRange(conDetList);

            DataBase cafe1 = new DataBase
            {
                Name = "Cafe 1",
                DatabaseInfo = "cafe 1 info",
                ConnectionDetails = conDet1
            };
            DataBase cafe2 = new DataBase
            {
                Name = "Cafe 2",
                DatabaseInfo = "cafe 2 info",
                ConnectionDetails = conDet2
            };
            DataBase manufacture = new DataBase
            {
                Name = "ManufactureDataBase",
                DatabaseInfo = "manufacture info",
                ConnectionDetails = conDet3
            };

            List<DataBase> dataBaseList = new List<DataBase> { cafe1, cafe2, manufacture };
            db.DataBases.AddRange(dataBaseList);
            db.SaveChanges();
        }
    }
}