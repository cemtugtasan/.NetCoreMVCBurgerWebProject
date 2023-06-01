//using FastFoodProject.Domain.Entities.MemberEntities;
//using FastFoodProject.Domain.IRepositories.IMemberRepositories;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace FastFoodProject.Infrustructure.Repositories.MemberRepositories
//{
//	public class MemberBaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
//		where TEntity : MemberBaseEntity
//		where TContext : IdentityDbContext
//	{
//		private readonly TContext _context;

//		public MemberBaseRepository(TContext context)
//		{
//			_context = context;
//		}

//		public async Task<bool> Create(TEntity entity)
//		{
//			await _context.Set<TEntity>().AddAsync(entity);
//			return await _context.SaveChangesAsync() > 0;
//		}

//		public async Task<bool> Delete(TEntity entity)
//		{
//			bool hasIsActive = HasOwnFood(typeof(TEntity), "IsActive");
//			if (hasIsActive)
//			{
//				entity.IsActive = false;
//				return await Update(entity);
//			}
//			else
//			{
//				_context.Set<TEntity>().Remove(entity);
//				return await _context.SaveChangesAsync() > 0;
//			}
//		}
//		public async Task<TEntity> GetById(string id)
//		{
//			return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

//		}

//		public async Task<IEnumerable<TEntity>> GetFilteredAll(Expression<Func<TEntity, bool>> filter = null)
//		{
//			return filter != null ? await _context.Set<TEntity>().Where(filter).ToListAsync() : await _context.Set<TEntity>().ToListAsync();
//		}

//		public async Task<bool> Update(TEntity entity)
//		{
//			_context.Entry(entity).State = EntityState.Modified;
//			return await _context.SaveChangesAsync() > 0;
//		}
//		private bool HasOwnFood(Type type, string name)
//		{
//			bool hasOwnFood = type.GetProperties().Any(p => p.Name == name);
//			return hasOwnFood;
//		}
//	}
//}
