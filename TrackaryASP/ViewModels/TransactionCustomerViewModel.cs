using System.Collections.Generic;
using TrackaryASP.Models;

namespace TrackaryASP.ViewModels
{
    public class TransactionCustomerViewModel
    {
        public Transaction Transaction { get; set; }
        public int? PickedCustomerID { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}