using System.Data.Entity;

using DAL.Entities;

namespace DAL.EF
{
	public class MetaContext : DbContext
	{
		public MetaContext(string connection)			
			: base(connection) { }

		public DbSet<DataBase> Databases { get; set; }
		public DbSet<ConnectionDetails> ConnectionDetails { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
		//	optionsBuilder.UseLazyLoadingProxies();
	}
}
