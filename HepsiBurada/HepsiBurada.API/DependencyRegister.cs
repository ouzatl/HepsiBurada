using HepsiBurada.Common.Logging;
using HepsiBurada.Data.Repositories.CampaignRepository;
using HepsiBurada.Data.Repositories.OrderRepository;
using HepsiBurada.Data.Repositories.ProductRepository;
using HepsiBurada.Service.Services.CampaignService;
using HepsiBurada.Service.Services.OrderService;
using HepsiBurada.Service.Services.ProductService;
using Microsoft.Extensions.DependencyInjection;

namespace HepsiBurada.API
{
    public class DependencyRegister
    {
        private readonly IServiceCollection _services;
        public DependencyRegister(IServiceCollection services)
        {
            _services = services;
        }

        public void Register()
        {
            //Services
            _services.AddScoped<IProductService, ProductService>();
            _services.AddScoped<ICampaignService, CampaignService>();
            _services.AddScoped<IOrderService, OrderService>();

            //Repositories
            _services.AddScoped<IProductRepository, ProductRepository>();
            _services.AddScoped<ICampaignRepository, CampaignRepository>();
            _services.AddScoped<IOrderRepository, OrderRepository>();

            //Others
            //_services.AddScoped<xHelper>();
            _services.AddSingleton<ICompositeLogger, CompositeLogger>();
        }
    }
}