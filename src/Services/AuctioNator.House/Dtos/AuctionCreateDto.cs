using System.ComponentModel.DataAnnotations;

namespace AuctioNator.House.Dtos
{
    public class AuctionCreateDto
    {
        [Required]
        public string Name {get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public int Price { get; set; }
        [Required]
        public string SellerId { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }

    }
}
