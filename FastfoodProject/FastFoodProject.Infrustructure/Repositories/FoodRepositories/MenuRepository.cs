using FastFoodProject.Domain.Entities.FoodEntities;
using FastFoodProject.Domain.IRepositories.IFoodRepositories;
using FastFoodProject.Infrustructure.ModelContext;

namespace FastFoodProject.Infrustructure.Repositories.FoodRepositories
{
	public class MenuRepository : FoodBaseRepository<Menu, ApplicationDbContext>, IMenuRepository
	{
		private readonly ApplicationDbContext _context;

		public MenuRepository(ApplicationDbContext context) : base(context)
		{
			this._context = context;
		}

		public async Task<bool> CreateRangeForDrink(List<Drink> drinks)
		{
			await _context.AddRangeAsync(drinks);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> CreateRangeForEat(List<Eat> eats)
		{
			await _context.AddRangeAsync(eats);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> CreateRangeForExtra(List<Extra> ekstras)
		{
			await _context.AddRangeAsync(ekstras);
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
