using System.ComponentModel.DataAnnotations;

namespace TrackaryASP.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Range(1, 1000)]
        public int Quantity { get; set; }

        public bool InStock
        {
            get
            {
                return Quantity > 0;
            }
        }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
    }
}