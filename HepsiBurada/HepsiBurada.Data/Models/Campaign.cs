using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HepsiBurada.Data.Models
{
    public class Campaign
    {
        [Key]
        [MaxLength(10)]
        public string Name { get; set; }
        [ForeignKey("Product")]
        [MaxLength(10)]
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public Product Products { get; set; }
    }
}