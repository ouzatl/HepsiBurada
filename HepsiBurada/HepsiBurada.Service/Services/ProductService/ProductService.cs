using AutoMapper;
using HepsiBurada.Common.Logging;
using HepsiBurada.Contract.Contracts.Product;
using HepsiBurada.Data.Models;
using HepsiBurada.Data.Repositories.CampaignRepository;
using HepsiBurada.Data.Repositories.ProductRepository;
using System.Threading.Tasks;

namespace HepsiBurada.Service.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly ICompositeLogger _logger;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository productRepository,
            ICampaignRepository campaignRepository,
            ICompositeLogger logger,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _campaignRepository = campaignRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> CreateProduct(ProductContract product)
        {
            try
            {
                if (product == null || string.IsNullOrEmpty(product.ProductCode))
                    return false;

                var productModel = _mapper.Map<Product>(product);
                await _productRepository.Add(productModel);
            }
            catch (System.Exception ex)
            {
                _logger.Error("CreateProduct", ex);
                return false;
            }

            return true;
        }

        public async Task<ProductContract> GetProductInfo(string productCode)
        {
            try
            {
                var product = await _productRepository.GetProductInfo(productCode);
                //var productCampaign = _campaignRepository.GetCampaign(productCode);
                var productContract = _mapper.Map<ProductContract>(product);

                return productContract;
            }
            catch (System.Exception ex)
            {
                _logger.Error("GetProductInfo", ex);
                return null;
            }
        }
    }
}