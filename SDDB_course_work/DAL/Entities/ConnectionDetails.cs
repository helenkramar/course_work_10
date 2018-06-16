using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ConnectionDetails
    {
        [Key]
        [ForeignKey(nameof(DataBase))]
		public int Id { get; set; }

		public string Host { get; set; }
		public string DatabaseName { get; set; }
		public bool IntegratedSecurity { get; set; }

        public virtual DataBase DataBase { get; set; }
    }
}
