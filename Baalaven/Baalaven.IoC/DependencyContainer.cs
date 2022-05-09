using Baalaven.Entities.Interfaces;
using Baalaven.Repositories.EFCore.ContextData;
using Baalaven.Repositories.EFCore.Repositories;
using Baalaven.UseCases.Common.Behaviors;
using Baalaven.UseCases.CreateOrder;
using Baalaven.UsesCases.CreateOrder;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalaven.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddBaalavenServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaalavenContext>(options => options.UseSqlServer(configuration.GetConnectionString("BaalavenDB")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMediatR(typeof(CreateOrderInteractor));
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
