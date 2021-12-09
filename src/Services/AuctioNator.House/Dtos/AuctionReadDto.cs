namespace AuctioNator.House.Dtos
{
    public class AuctionReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Price { get; set; }
        public string SellerId { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
