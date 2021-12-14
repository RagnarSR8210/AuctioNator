using System.ComponentModel.DataAnnotations;

namespace AuctioNator.House.Models
{
    public class Auctions
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public int Price { get; set; }
        [Required]
        public string SellerId { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public int ExternalId { get; set; }

        public ICollection<Auctions> Houses { get; set; } = new List<Auctions>();
    }
}
