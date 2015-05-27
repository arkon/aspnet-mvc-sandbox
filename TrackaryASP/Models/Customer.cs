using System.ComponentModel.DataAnnotations;

namespace TrackaryASP.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public int StudentNumber { get; set; }

        public int TCardBarcode { get; set; }
    }
}