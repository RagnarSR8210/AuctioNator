using System.ComponentModel.DataAnnotations;

namespace AuctioNator.House.Models
{
    public class Buyers
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public int ExternalID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Buyers> Houses { get; set; } = new List<Buyers>();
    }
}
