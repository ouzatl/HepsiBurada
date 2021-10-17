using HepsiBurada.Contract.Contracts.Order;
using System.Threading.Tasks;

namespace HepsiBurada.Service.Services.OrderService
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(OrderContract order);
    }
}