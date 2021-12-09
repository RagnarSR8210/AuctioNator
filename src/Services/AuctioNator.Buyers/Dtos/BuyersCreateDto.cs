using System.ComponentModel.DataAnnotations;

namespace AuctioNator.Buyers.Dtos
{
    public class BuyersCreateDto
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
