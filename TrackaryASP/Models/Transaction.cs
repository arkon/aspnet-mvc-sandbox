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

        public virtual Cart Cart { get; set; }

        public virtual Customer Customer { get; set; }
    }
}