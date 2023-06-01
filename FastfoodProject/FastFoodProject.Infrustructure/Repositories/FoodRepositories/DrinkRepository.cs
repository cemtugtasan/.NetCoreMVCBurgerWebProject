using FastFoodProject.Domain.Entities.FoodEntities;
using FastFoodProject.Domain.IRepositories.IFoodRepositories;
using FastFoodProject.Infrustructure.ModelContext;

namespace FastFoodProject.Infrustructure.Repositories.FoodRepositories
{
	public class DrinkRepository : FoodBaseRepository<Drink, ApplicationDbContext>, IDrinkRepository
	{
		private readonly ApplicationDbContext _context;

		public DrinkRepository(ApplicationDbContext context):base(context)
		{
			this._context = context;
		}	
	}
}
