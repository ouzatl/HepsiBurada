using AutoMapper;
using HepsiBurada.Common.Logging;
using HepsiBurada.Contract.Contracts.Order;
using HepsiBurada.Data.Models;
using HepsiBurada.Data.Repositories.OrderRepository;
using HepsiBurada.Data.Repositories.ProductRepository;
using HepsiBurada.Service.Services.OrderService;
using HepsiBurada.Test.Moqs;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace HepsiBurada.Test.Tests
{
    public class OrderTest
    {
        [Fact]
        public async Task CREATE_ORDER_SUCCES_CASE()
        {
            var product = new Mock<IProductRepository>();
            var order = new Mock<IOrderRepository>();
            var mapper = new Mock<IMapper>();
            var logger = new Mock<ICompositeLogger>();

            product.Setup(p => p.GetProductInfo("P1"))
                .ReturnsAsync(new Product { ProductCode = "P1", Price = 100, Stock = 1000 });

            OrderService orderservice = new OrderService(order.Object, product.Object, logger.Object, mapper.Object);

            var result = await orderservice.CreateOrder(new OrderContract { ProductCode = "P1", Quantity = 3 });

            Assert.True(result);
        }

        [Fact]
        public async Task CREATE_ORDER_NULL_BODY_FAIL_CASE()
        {
            var result = await OrderMoq.GetOrderService()
                .CreateOrder(null);

            Assert.False(result);
        }

        [Fact]
        public async Task CREATE_ORDER_NULL_PRODUCT_CODE_FAIL_CASE()
        {
            var result = await OrderMoq.GetOrderService()
                .CreateOrder(new OrderContract { ProductCode = null, Quantity = 0 });

            Assert.False(result);
        }

        [Fact]
        public async Task CREATE_ORDER_EMPTY_PRODUCT_CODE_FAIL_CASE()
        {
            var result = await OrderMoq.GetOrderService()
                .CreateOrder(new OrderContract { ProductCode = "", Quantity = 0 });

            Assert.False(result);
        }
    }
}