using AutoMapper;
using HepsiBurada.Common.Constants;
using HepsiBurada.Common.Logging;
using HepsiBurada.Contract.Contracts.Product;
using HepsiBurada.Data.Models;
using HepsiBurada.Data.Repositories.CampaignRepository;
using HepsiBurada.Data.Repositories.ProductRepository;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace HepsiBurada.Service.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly ICompositeLogger _logger;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly string cacheKey = CacheKeyConstant.CURRENT_HOUR;

        public ProductService(
            IProductRepository productRepository,
            ICampaignRepository campaignRepository,
            ICompositeLogger logger,
            IMapper mapper,
            IMemoryCache memoryCache
            )
        {
            _productRepository = productRepository;
            _campaignRepository = campaignRepository;
            _logger = logger;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<bool> CreateProduct(ProductContract product)
        {
            try
            {
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
                var currentDuration = _memoryCache.Get(cacheKey);
                var productCampaign = await _campaignRepository.GetCampaign(productCode, (int)currentDuration);
                if (productCampaign != null)
                    product.Price = product.Price -(product.Price * productCampaign.PriceManipulationLimit / 100);

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