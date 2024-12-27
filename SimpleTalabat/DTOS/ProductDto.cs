using Talabat.Core.Entities;

namespace SimpleTalabat.DTOS
{
    public class ProductDto
    {

        public string Name  { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; } 
        public int CategoryId { get; set; } 
        public string Brand { get; set; } //navigational property one
        public string Category { get; set; } //navigational property one
    }
}
