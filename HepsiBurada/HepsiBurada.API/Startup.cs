using HepsiBurada.Common.Constants;
using HepsiBurada.Data;
using HepsiBurada.Data.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HepsiBurada.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Dependency Injection
            DependencyInjection(services);
            //Swagger
            AddSwagger(services);
            //PostgreSql Connection
            SqlConnection(services);
            services.AddLogging();
            services.AddControllers();
            //Mapping
            services.AddAutoMapper(typeof(Mapping));
            //In-Memory Cache
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
        }

        private void SqlConnection(IServiceCollection services)
        {

            //services.AddEntityFrameworkNpgsql().AddDbContext<HepsiBuradaContext>(opt =>
            //                   opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            var connectionString= Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<HepsiBuradaContext>(options => options.UseSqlServer(connectionString));
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Core API", Description = "HepsiBurada API" });
            });
        }

        private void DependencyInjection(IServiceCollection services)
        {
            var dependency = new DependencyRegister(services);
            dependency.Register();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMemoryCache cache)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Swagger API UI
                app.UseSwagger();
                app.UseSwaggerUI(x =>
                {
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "HepsiBurada API");
                });

                TimeSimulation(cache);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void TimeSimulation(IMemoryCache cache)
        {
            var entryOptions = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.NeverRemove);
            var cacheKey = CacheKeyConstant.CURRENT_HOUR;
            cache.Set(cacheKey, default(int), entryOptions);
        }
    }
}