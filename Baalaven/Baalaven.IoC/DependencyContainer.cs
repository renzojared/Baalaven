using Baalaven.Entities.Interfaces;
using Baalaven.Presenters;
using Baalaven.Repositories.EFCore.DataContext;
using Baalaven.Repositories.EFCore.Repositories;
using Baalaven.UseCases.Common.Validators;
using Baalaven.UseCases.CreateOrder;
using Baalaven.UseCases.GetAllOrders;
using Baalaven.UseCases.MakePayment;
using Baalaven.UseCasesPorts.CreateOrder;
using Baalaven.UseCasesPorts.GetAllOrders;
using Baalaven.UseCasesPorts.MakePayment;
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
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentDetailRepository, PaymentDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(GetAllOrdersValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(MakePaymentValidator).Assembly);

            // Create Order
            services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
            services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();

            //Get Orders By Customer
            services.AddScoped<IGetAllOrdersInputPort, GetAllOrdersInteractor>();
            services.AddScoped<IGetAllOrdersOutputPort, GetAllOrdersPresenters>();

            //Make Payments
            services.AddScoped<IMakePaymentInputPort, MakePaymentInteractor>();
            services.AddScoped<IMakePaymentOutputPort, MakePaymentsPresenter>();

            return services;
        }
    }
}
