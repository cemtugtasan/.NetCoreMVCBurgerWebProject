using FastFoodProject.Application.DTOs.FoodDTOs.EatDTOs;
using FastFoodProject.Domain.Entities.FoodEntities;
using System.Linq.Expressions;

namespace FastFoodProject.Application.IServices.IFoodServices
{
	public interface IEatService
	{
		Task<bool> EatCreate(EatCreateDto eatCreateDto);
		Task<bool> EatUpdate(EatUpdateDto eatUpdateDto);
		Task<bool> EatDelete(int eatId);
		Task<IEnumerable<EatListDto>> EatList(Expression<Func<Eat, bool>> filter = null);
		Task<EatCreateDto> GetByEatId(int eatId);
	}
}
