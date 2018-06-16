using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class DataBase
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }
		public string DatabaseInfo { get; set; }

		public virtual ConnectionDetails ConnectionDetails { get; set; }

        //[Key]
        //public int Id { get; set; }
        //public string Name { get; set; }

        //public string Host { get; set; }
        //public string DatabaseName { get; set; }
        //public bool IntegratedSecurity { get; set; }
    }
}
