using Microsoft.Extensions.DependencyInjection;
using MoveIT.Services.Services.Contracts;
using MoveIT.Services.Services;

namespace MoveIT.Services.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddMoveIT(this IServiceCollection services)
    {
        services.AddScoped<IDistancePrice, DistancePrice>();
        services.AddScoped<IPriceCalculation, PriceCalculation>();
        services.AddScoped<IVolumePrice, VolumePrice>();
        services.AddScoped<IOrder, Order>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
