using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Interfaces.Repositories;
using OrderService.Infrastructure.Context;
using OrderService.Persistence.Context;
using OrderService.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            string a =  "Data Source=c_sqlserver;Initial Catalog=order;Persist Security Info=True;User ID=sa;Password=Halid35!";
            ;

            services.AddDbContext<OrderDbContext>(opt =>
            {
                opt.UseSqlServer(a);
                opt.EnableSensitiveDataLogging();
            });

            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>()
                .UseSqlServer(a);

            using var dbContext = new OrderDbContext(optionsBuilder.Options, null);
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();

            return services;
        }
    }
}
