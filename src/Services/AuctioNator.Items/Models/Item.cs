using System.ComponentModel.DataAnnotations;

namespace AuctioNator.Items.Models
{
    public class Item
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Price { get; set; }

        public string Maker { get; set; }

        public string Brand { get; set; }
    }
}
