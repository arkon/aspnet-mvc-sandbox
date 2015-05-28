using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackaryASP.Models
{
    [Serializable]
    public class Cart
    {
        [Key]
        public int ID { get; set; }

        public virtual SortedDictionary<Product, int> Products { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DataType(DataType.Currency)]
        [Display(Name = "Total Cost")]
        public decimal TotalCost
        {
            get
            {
                decimal total = Products.Sum(x => x.Key.Price * x.Value);
                return Decimal.Parse(total.ToString("0.00"));
            }
            private set { }
        }

        public Cart()
        {
            this.Products = new SortedDictionary<Product, int>();
        }

        public void Add(Product product)
        {
            if (Products.ContainsKey(product))
            {
                Products[product]++;
            }
            else
            {
                Products.Add(product, 1);
            }
        }
    }
}