using FastFoodProject.Application.DTOs.FoodDTOs.MenuDTOs;
using FastFoodProject.Domain.Entities.FoodEntities;
using System.Linq.Expressions;

namespace FastFoodProject.Application.IServices.IFoodServices
{
	public interface IMenuService
	{
		Task<bool> MenuCreate(MenuCreateDto menuCreateDto);
		Task<bool> MenuUpdate(MenuUpdateDto menuUpdateDto);
		Task<bool> MenuDelete(int menuId);
		Task<IEnumerable<MenuListDto>> MenuList(Expression<Func<Menu, bool>> filter = null);
		Task<MenuCreateDto> GetByMenuId(int menuId);
	}
}
