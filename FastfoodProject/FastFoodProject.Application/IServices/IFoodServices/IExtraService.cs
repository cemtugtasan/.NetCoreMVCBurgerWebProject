using FastFoodProject.Application.DTOs.FoodDTOs.ExtraDTOs;
using FastFoodProject.Domain.Entities.FoodEntities;
using System.Linq.Expressions;

namespace FastFoodProject.Application.IServices.IFoodServices
{
	public interface IExtraService
	{
		Task<bool> ExtraCreate(ExtraCreateDto extraCreateDto);
		Task<bool> ExtraUpdate(ExtraUpdateDto extraUpdateDto);
		Task<bool> ExtraDelete(int extraId);
		Task<IEnumerable<ExtraListDto>> ExtraList(Expression<Func<Extra, bool>> filter = null);
		Task<ExtraCreateDto> GetByExtraId(int extraId);
	}
}
