using System.ComponentModel.DataAnnotations;

namespace AuctioNator.Sellers.Dtos
{
    public class SellersCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
