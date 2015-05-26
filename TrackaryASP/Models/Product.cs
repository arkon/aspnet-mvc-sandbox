using System.ComponentModel.DataAnnotations;

namespace TrackaryASP.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool InStock
        {
            get
            {
                return Quantity > 0;
            }
        }
    }
}