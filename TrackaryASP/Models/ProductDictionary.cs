using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackaryASP.Models
{
    public class ProductDictionary
    {
        public int ID { get; set; }
        public virtual Product Key { get; set; }
        public int Value { get; set; }
    }
}