using Baalaven.Entities.Interfaces;
using Baalaven.Presenters;
using Baalaven.Repositories.EFCore.DataContext;
using Baalaven.Repositories.EFCore.Repositories;
using Baalaven.UseCases.Common.Validators;
using Baalaven.UseCases.CreateOrder;
using Baalaven.UseCasesPorts.CreateOrder;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
            services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();
            return services;
        }
    }
}
