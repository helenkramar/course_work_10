using System.Data.Entity;

using DAL.Entities;

namespace DAL.EF
{
	public class MetaContext : DbContext
	{
		public MetaContext(string connection) : base(connection) { }

		public DbSet<DataBase> DataBases { get; set; }
		public DbSet<ConnectionDetails> ConnectionDetails { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        //	optionsBuilder.UseLazyLoadingProxies();

	    static MetaContext()
	    {
	        System.Data.Entity.Database.SetInitializer<MetaContext>(new MetaInitializer());
	    }
    }
}
