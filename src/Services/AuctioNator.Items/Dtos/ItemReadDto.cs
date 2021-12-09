using System.ComponentModel.DataAnnotations;

namespace AuctioNator.Items.Dtos
{
    public class ItemReadDto
    {        
        public int Id { get; set; }
        public string Name { get; set; }  
        public int Age { get; set; }      
        public double Price { get; set; }
        public string Maker { get; set; }
        public string Brand { get; set; }
    }
}
