using AutoMapper;
using HepsiBurada.Common.Logging;
using HepsiBurada.Data.Repositories.OrderRepository;
using HepsiBurada.Data.Repositories.ProductRepository;
using HepsiBurada.Service.Services.OrderService;
using Moq;

namespace HepsiBurada.Test.Moqs
{
    public class OrderMoq
    {
        #region Moqs

        public static ICompositeLogger LoggerMoq() => Mock.Of<ICompositeLogger>();
        public static IOrderRepository OrderRepositoryMoq() => Mock.Of<IOrderRepository>();
        public static IProductRepository ProductRepositoryMoq() => Mock.Of<IProductRepository>();
        public static IMapper MapperMoq() => Mock.Of<IMapper>();

        #endregion

        #region GetMoqs

        public static IOrderService GetOrderService() => new OrderService(OrderRepositoryMoq(), ProductRepositoryMoq(), LoggerMoq(), MapperMoq());

        #endregion
    }
}