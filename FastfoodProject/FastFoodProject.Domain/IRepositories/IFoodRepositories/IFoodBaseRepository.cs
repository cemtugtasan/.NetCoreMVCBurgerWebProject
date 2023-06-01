using FastFoodProject.Domain.Entities.FoodEntities;
using System.Linq.Expressions;

namespace FastFoodProject.Domain.IRepositories.IFoodRepositories
{
	public interface IFoodBaseRepository<TEntity> where TEntity : FoodBaseEntity
	{
		Task<bool> Create(TEntity entity);
		Task<bool> Update(TEntity entity);
		Task<bool> Delete(TEntity entity);
		Task<TEntity> GetById(int id);
		Task<IEnumerable<TEntity>> GetFilteredAll(Expression<Func<TEntity, bool>> filter = null!);
		//Task<int> GetIdByName(string name);
		//Task<bool> CreateRangeForEat(List<Eat> eats);
		//Task<bool> CreateRangeForDrink(List<Drink> drinks);
		//Task<bool> CreateRangeForExtra(List<Extra> ekstras);
		//Task<bool> CreateRangeForMenu(List<Menu> menus);
		
	}
}
