using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ConnectionDetails
    {
		[ForeignKey(nameof(DataBase)),
			DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Host { get; set; }
		public string DatabaseName { get; set; }
		public bool IntegratedSecurity { get; set; }


        //[Key]
        //[ForeignKey("ConnectionDeatils")]
        //public int Id { get; set; }

        //public virtual Database Database { get; set; }
    }
}
