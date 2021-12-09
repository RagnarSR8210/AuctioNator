using System.ComponentModel.DataAnnotations;

namespace AuctioNator.House.Models
{
    public class Items
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int ExternalID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Houses> Houses { get; set; } = new List<Houses>();
    }
}
