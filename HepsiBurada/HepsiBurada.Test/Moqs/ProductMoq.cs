using AutoMapper;
using HepsiBurada.Common.Logging;
using HepsiBurada.Data.Repositories.CampaignRepository;
using HepsiBurada.Data.Repositories.ProductRepository;
using HepsiBurada.Service.Services.ProductService;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace HepsiBurada.Test.Moqs
{
    public class ProductMoq
    {
        #region Moqs

        public static ICompositeLogger LoggerMoq() => Mock.Of<ICompositeLogger>();
        public static IProductRepository ProductRepositoryMoq() => Mock.Of<IProductRepository>();
        public static ICampaignRepository CampaignRepositoryMoq() => Mock.Of<ICampaignRepository>();
        public static IMapper MapperMoq() => Mock.Of<IMapper>();
        public static IMemoryCache MemoryCacheMoq() => Mock.Of<IMemoryCache>();

        #endregion

        #region GetMoqs

        public static IProductService GetProductService() => new ProductService(ProductRepositoryMoq(), CampaignRepositoryMoq(), LoggerMoq(), MapperMoq(), MemoryCacheMoq());

        #endregion
    }
}