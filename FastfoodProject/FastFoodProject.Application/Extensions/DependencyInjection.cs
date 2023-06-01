using FastFoodProject.Application.IServices;
using FastFoodProject.Application.IServices.IFoodServices;
using FastFoodProject.Application.IServices.IMemberServices;
using FastFoodProject.Application.Services;
using FastFoodProject.Application.Services.FoodService;
using Microsoft.Extensions.DependencyInjection;

namespace FastFoodProject.Application.Extensions
{
	public static class DependencyInjection
	{
		public static IServiceCollection AppDependencyResolver(this IServiceCollection services)
		{
			services.AddScoped<IDrinkService, DrinkService>().
				AddScoped<IEatService, EatService>().
				AddScoped<IExtraService, ExtraService>().
				AddScoped<IMenuService, MenuService>().
				AddScoped<IOrderService, OrderService>();
				
			return services;
		}
	}
}
