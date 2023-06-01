using FastFoodProject.Domain.Entities;
using FastFoodProject.Domain.Entities.FoodEntities;
using System.Linq.Expressions;

namespace FastFoodProject.Domain.IRepositories
{
	public interface IOrderRepository
	{
		Task<bool> Create(Order order);
		Task<bool> Update(Order order);
		Task<bool> Delete(Order order);
		Task<Order> GetById(int id);
		Task<IEnumerable<Order>> GetFilteredAll(Expression<Func<Order, bool>> filter = null!);
		Task<bool> CreateRangeForEat(List<Eat> eats);
		Task<bool> CreateRangeForDrink(List<Drink> drinks);
		Task<bool> CreateRangeForExtra(List<Extra> ekstras);
		Task<bool> CreateRangeForMenu(List<Menu> menus);
	}
}
