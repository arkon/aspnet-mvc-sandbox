using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TrackaryASP.Models
{
    [Serializable]
    public class CartSessionData
    {
        public CartSessionData()
        {
            this.Products = new List<Product>();
        }

        [Key]
        public int ID { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public decimal TotalCost
        {
            get
            {
                return Products.Sum(x => x.Price);
            }
        }
    }
}