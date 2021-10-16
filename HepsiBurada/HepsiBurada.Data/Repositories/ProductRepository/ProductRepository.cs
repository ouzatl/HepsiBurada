using HepsiBurada.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HepsiBurada.Data.Repositories.ProductRepository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DbContext _dbContext;

        public ProductRepository(HepsiBuradaContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}