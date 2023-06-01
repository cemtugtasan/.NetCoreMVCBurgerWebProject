using FastFoodProject.Domain.Entities.FoodEntities;
using FastFoodProject.Domain.IRepositories.IFoodRepositories;
using FastFoodProject.Infrustructure.ModelContext;

namespace FastFoodProject.Infrustructure.Repositories.FoodRepositories
{
	public class ExtraRepository : FoodBaseRepository<Extra, ApplicationDbContext>, IExtraRepository
	{
		private readonly ApplicationDbContext _context;

		public ExtraRepository(ApplicationDbContext context) : base(context)
		{
			this._context = context;
		}
	}
}
