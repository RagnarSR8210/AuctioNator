using System.Text.Json.Serialization;

namespace Auctionator.Client.Data
{
    public class ItemsDto
    {     
        [JsonPropertyName("id")]
        public int Id { get; set; }   
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("age")]
        public int Age { get; set; }   
        [JsonPropertyName("price")]
        public int Price { get; set; }
        [JsonPropertyName("maker")]
        public string Maker { get; set; }
        [JsonPropertyName("brand")]
        public string Brand { get; set; }
    }
}
