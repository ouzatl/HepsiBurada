using HepsiBurada.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HepsiBurada.Data
{
    public class HepsiBuradaContext : DbContext
    {
        public HepsiBuradaContext(DbContextOptions<HepsiBuradaContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}