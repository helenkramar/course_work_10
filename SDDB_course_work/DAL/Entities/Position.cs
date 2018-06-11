using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0, 100)]
        public int Amount { get; set; }
    }
}