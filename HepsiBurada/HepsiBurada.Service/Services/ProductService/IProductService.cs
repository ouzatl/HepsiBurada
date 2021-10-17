using HepsiBurada.Contract.Contracts.Product;
using System.Threading.Tasks;

namespace HepsiBurada.Service.Services.ProductService
{
    public interface IProductService
    {
        Task<bool> CreateProduct(ProductContract product);
        Task<ProductContract> GetProductInfo(string productCode);
    }
}