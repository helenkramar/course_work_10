using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ConnectionDetails
    {
        [Key]
        [ForeignKey("ConnectionDeatils")]
        public int Id { get; set; }

        public virtual Database Database { get; set; }
    }
}
