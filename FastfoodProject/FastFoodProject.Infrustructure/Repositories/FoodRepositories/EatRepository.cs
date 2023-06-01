using FastFoodProject.Domain.Entities.FoodEntities;
using FastFoodProject.Domain.IRepositories.IFoodRepositories;
using FastFoodProject.Infrustructure.ModelContext;

namespace FastFoodProject.Infrustructure.Repositories.FoodRepositories
{
	public class EatRepository:FoodBaseRepository<Eat,ApplicationDbContext>,IEatRepository
	{
		private readonly ApplicationDbContext _context;

		public EatRepository(ApplicationDbContext context):base(context)
		{
			this._context = context;
		}
	}
}
