using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Database
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ConnectionDetails ConnectionDetails { get; set; }
    }
}
