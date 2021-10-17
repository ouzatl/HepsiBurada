using HepsiBurada.Contract.Contracts.Order;
using HepsiBurada.Test.Moqs;
using System.Threading.Tasks;
using Xunit;

namespace HepsiBurada.Test.Tests
{
    public class OrderTest
    {
        [Fact]
        public async Task CREATE_ORDER_SUCCES_CASE()
        {
            var result = await OrderMoq.GetOrderService()
                .CreateOrder(new OrderContract { ProductCode = "P1", Quantity = 3 });

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