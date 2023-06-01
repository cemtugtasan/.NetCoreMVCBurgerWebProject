using FastFoodProject.Domain.Entities.FoodEntities;

namespace FastFoodProject.Domain.IRepositories.IFoodRepositories
{
	public interface IMenuRepository : IFoodBaseRepository<Menu>
	{
		Task<bool> CreateRangeForEat(List<Eat> eats);
		Task<bool> CreateRangeForDrink(List<Drink> drinks);
		Task<bool> CreateRangeForExtra(List<Extra> ekstras);
	}
}
