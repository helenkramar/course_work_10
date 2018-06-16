using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class DataBase
    {
        [Key]
		public int Id { get; set; }

		public string Name { get; set; }
		public string DatabaseInfo { get; set; }
        
		public virtual ConnectionDetails ConnectionDetails { get; set; }
    }
}
