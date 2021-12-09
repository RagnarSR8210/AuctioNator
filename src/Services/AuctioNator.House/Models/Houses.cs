namespace AuctioNator.House.Models
{
    public class Houses
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string HouseLine { get; set; }

        public int ItemId { get; set; }

        public Items Item { get; set; }

    }
}
