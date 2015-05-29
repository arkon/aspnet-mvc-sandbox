using System;
using System.ComponentModel.DataAnnotations;

namespace TrackaryASP.Models
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Date/Time")]
        public DateTime TransactionDateTime { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [DataType(DataType.Currency)]
        public decimal Rewards { get; set; }

        public String Items { get; set; }

        public virtual Customer Customer { get; set; }
    }
}