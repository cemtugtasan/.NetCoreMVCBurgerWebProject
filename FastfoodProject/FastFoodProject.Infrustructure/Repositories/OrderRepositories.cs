using FastFoodProject.Domain.Entities;
using FastFoodProject.Domain.Entities.FoodEntities;
using FastFoodProject.Domain.IRepositories;
using FastFoodProject.Infrustructure.ModelContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FastFoodProject.Infrustructure.Repositories
{
	public class OrderRepositories: IOrderRepository
		
	{
		private readonly ApplicationDbContext _context;
		public OrderRepositories(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Create(Order order)
		{
			await _context.Set<Order>().AddAsync(order);
			return await _context.SaveChangesAsync() > 0;
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

		public async Task<bool> CreateRangeForMenu(List<Menu> menus)
		{
			await _context.AddRangeAsync(menus);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Delete(Order order)
		{
			_context.Set<Order>().Remove(order);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<Order> GetById(int id)
		{
			return await _context.Set<Order>().FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
		}

		public async Task<IEnumerable<Order>> GetFilteredAll(Expression<Func<Order, bool>> filter = null!)
		{
			return filter != null ? await _context.Set<Order>().Where(filter).ToListAsync()
			   : await _context.Set<Order>().ToListAsync();
		}

		public async Task<bool> Update(Order order)
		{
			_context.Entry(order).State = EntityState.Modified;
			
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
