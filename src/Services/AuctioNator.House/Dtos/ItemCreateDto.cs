using System.ComponentModel.DataAnnotations;

namespace AuctioNator.House.Dtos
{
    public class ItemCreateDto
    {
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
