using FastFoodProject.Application.DTOs.FoodDTOs.DrinkDTOs;
using FastFoodProject.Domain.Entities.FoodEntities;
using System.Linq.Expressions;

namespace FastFoodProject.Application.IServices.IFoodServices
{
	public interface IDrinkService
	{
		Task<bool> DrinkCreate(DrinkCreateDto drinkCreateDto);
		Task<bool> DrinkUpdate(DrinkUpdateDto drinkUpdateDto);
		Task<bool> DrinkDelete(int drinkId);
		Task<IEnumerable<DrinkListDto>> DrinkList(Expression<Func<Drink, bool>> filter = null);
		Task<DrinkCreateDto> GetByDrinkId(int drinkId);
	}
}
