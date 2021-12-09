namespace AuctioNator.House.Dtos
{
    public class AuctionPublishedDto
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;      
        public int Price { get; set; } 
        public string SellerId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Event { get; internal set; }
    }
}
