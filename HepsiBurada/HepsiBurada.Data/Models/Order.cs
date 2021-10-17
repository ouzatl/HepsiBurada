using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HepsiBurada.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        [ForeignKey("Product")]
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public Product Products { get; set; }
    }
}