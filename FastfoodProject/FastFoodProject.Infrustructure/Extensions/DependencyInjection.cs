using FastFoodProject.Domain.IRepositories;
using FastFoodProject.Domain.IRepositories.IFoodRepositories;
using FastFoodProject.Infrustructure.ModelContext;
using FastFoodProject.Infrustructure.Repositories;
using FastFoodProject.Infrustructure.Repositories.FoodRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastFoodProject.Infrustructure.Extensions
{
	public static class DependencyInjection
	{
		public static IServiceCollection InfDependencyResolver(this IServiceCollection services)
		{
			services.AddScoped<IDrinkRepository, DrinkRepository>()
					.AddScoped<IEatRepository, EatRepository>()
					.AddScoped<IExtraRepository, ExtraRepository>()
					.AddScoped<IMenuRepository, MenuRepository>()
					.AddScoped<IOrderRepository, OrderRepositories>();
			return services;
		}
	}
}
