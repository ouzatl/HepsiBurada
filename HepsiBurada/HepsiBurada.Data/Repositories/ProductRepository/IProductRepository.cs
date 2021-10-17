using HepsiBurada.Data.Models;
using System.Threading.Tasks;

namespace HepsiBurada.Data.Repositories.ProductRepository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetProductInfo(string productCode);
    }
}