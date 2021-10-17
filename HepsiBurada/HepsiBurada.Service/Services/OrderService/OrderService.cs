using AutoMapper;
using HepsiBurada.Common.Logging;
using HepsiBurada.Contract.Contracts.Order;
using HepsiBurada.Data.Models;
using HepsiBurada.Data.Repositories.OrderRepository;
using HepsiBurada.Data.Repositories.ProductRepository;
using System.Threading.Tasks;

namespace HepsiBurada.Service.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICompositeLogger _logger;
        private readonly IMapper _mapper;

        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            ICompositeLogger logger,
            IMapper mapper
            )
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> CreateOrder(OrderContract order)
        {
            try
            {
                var product = await _productRepository.GetProductInfo(order.ProductCode);
                if (product.Stock < order.Quantity)
                    return false;

                var orderModel = _mapper.Map<Order>(order);
                await _orderRepository.Add(orderModel);
                product.Stock -= order.Quantity;
                await _productRepository.Update(product);
            }
            catch (System.Exception ex)
            {
                _logger.Error("CreateOrder", ex);
                return false;
            }

            return true;
        }

    }
}