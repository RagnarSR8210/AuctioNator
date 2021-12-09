namespace Auctionator.Client.Data
{
    public class Items
    {
        public int Id { get; set; }       
        public string Name { get; set; }      
        public int Age { get; set; }       
        public int Price { get; set; }
        public int OriginalPrice { get; set; }
        public string Maker { get; set; }
        public string Brand { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int  CategoryId { get; set; }
    }
}
