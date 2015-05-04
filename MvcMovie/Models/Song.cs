using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Song : Merch
    {
        [Required]
        public string Artist { get; set; }
    }
}