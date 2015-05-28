using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrackaryASP.Models
{
    [Serializable]
    public class Cart
    {
        [Key]
        public int ID { get; set; }

        public List<ProductDictionary> Products { get; set; }

        private decimal _totalcost;

        [DataType(DataType.Currency)]
        [Display(Name = "Total Cost")]
        public decimal TotalCost
        {
            get
            {
                _totalcost = CalculateTotalCost();
                return _totalcost;
            }
            set {
                _totalcost = CalculateTotalCost();
            }
        }

        private decimal CalculateTotalCost()
        {
            decimal total = Products.Sum(x => x.Key.Price * x.Value);
            return Decimal.Parse(total.ToString("0.00"));
        }

        public Cart()
        {
            this.Products = new List<ProductDictionary>();
        }

        public void Add(Product product)
        {
            ProductDictionary existing = Products.Find(p => p.Key.Name == product.Name);

            if (existing != null)
            {
                existing.Value++;
            }
            else
            {
                Products.Add(new ProductDictionary { Key = product, Value = 1 });
            }
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            foreach (ProductDictionary p in Products)
            {
                sb.AppendFormat("{0} x {1} @ {2} each\n", p.Value, p.Key.Name, p.Key.Price);
            }

            return sb.ToString();
        }
    }
}