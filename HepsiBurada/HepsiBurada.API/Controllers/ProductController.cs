using System.Threading.Tasks;
using HepsiBurada.Common.Logging;
using HepsiBurada.Contract.Contracts.Product;
using HepsiBurada.Service.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace HepsiBurada.API.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICompositeLogger _logger;

        public ProductController(
            IProductService productService,
            ICompositeLogger logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost("create_product")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductContract product)
        {
            var result = await _productService.CreateProduct(product);
            if (result)
                return Ok($"Product created; code {product.ProductCode}, price {product.Price}, stock {product.Stock}");
            else
                return NoContent();
        }

        [HttpGet("get_product_info")]
        public async Task<IActionResult> GetProductInfo(string productCode)
        {
            var result = await _productService.GetProductInfo(productCode);
            if (result != null)
                return Ok($"Product {productCode} info; price {result.Price}, stock {result.Stock}");
            else
                return NotFound();
        }
    }
}