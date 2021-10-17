using AutoMapper;
using HepsiBurada.Common.Logging;
using HepsiBurada.Data.Repositories.ProductRepository;
using HepsiBurada.Service.Services.ProductService;
using Moq;

namespace HepsiBurada.Test.Moqs
{
    public class ProductMoq
    {
        #region Moqs

        public static ICompositeLogger LoggerMoq() => Mock.Of<ICompositeLogger>();
        public static IProductRepository ProductRepositoryMoq() => Mock.Of<IProductRepository>();
        public static IMapper MapperMoq() => Mock.Of<IMapper>();

        #endregion

        #region GetMoqs

        public static IProductService GetProductService() => new ProductService(ProductRepositoryMoq(), LoggerMoq(), MapperMoq());

        #endregion
    }
}