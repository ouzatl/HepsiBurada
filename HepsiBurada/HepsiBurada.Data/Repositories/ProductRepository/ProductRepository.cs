using HepsiBurada.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HepsiBurada.Data.Repositories.ProductRepository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DbContext _dbContext;

        public ProductRepository(HepsiBuradaContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductInfo(string productCode)
        {
            var product = await _dbContext.Set<Product>()
                .FirstOrDefaultAsync(x => x.ProductCode == productCode);

            return product;
        }
    }
}