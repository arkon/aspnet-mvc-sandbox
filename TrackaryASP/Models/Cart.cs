using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TrackaryASP.Models
{
    [Serializable]
    public class Cart
    {
        public int ID { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalCost
        {
            get
            {
                return Decimal.Parse(Products.Sum(x => x.Price).ToString("0.00"));
            }
        }
    }
}