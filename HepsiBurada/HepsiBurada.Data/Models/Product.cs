using System.ComponentModel.DataAnnotations;

namespace HepsiBurada.Data.Models
{
    public class Product
    {
        [Key]
        [MaxLength(10)]
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}