using System.Collections.Generic;
using TrackaryASP.Models;

namespace TrackaryASP.ViewModels
{
    public class ProductCartViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Cart> Cart { get; set; }
    }
}