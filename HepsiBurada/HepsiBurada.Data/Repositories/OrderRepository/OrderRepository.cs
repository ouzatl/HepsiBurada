using HepsiBurada.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HepsiBurada.Data.Repositories.OrderRepository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly DbContext _dbContext;

        public OrderRepository(HepsiBuradaContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}