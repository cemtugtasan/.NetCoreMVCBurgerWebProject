using FastFoodProject.Application.DTOs.FoodDTOs.MenuDTOs;
using FastFoodProject.Application.IServices.IFoodServices;
using FastFoodProject.Domain.Entities.FoodEntities;
using FastFoodProject.Domain.IRepositories.IFoodRepositories;
using System.Linq.Expressions;

namespace FastFoodProject.Application.Services.FoodService
{
	public class MenuService : IMenuService
    {
        private readonly IMenuRepository menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public async Task<MenuCreateDto> GetByMenuId(int menuId)
        {
            Menu menu = await menuRepository.GetById(menuId);
            MenuCreateDto dto = new MenuCreateDto
            {
                Name = menu.Name,
                ImagePath = menu.ImagePath,
                Price = menu.Price,
            };
            return dto;
        }

        public async Task<bool> MenuCreate(MenuCreateDto menuCreateDto)
        {
            Menu menu = new Menu
            {
                Name = menuCreateDto.Name,
                Price = menuCreateDto.Price,
                CreateDate = menuCreateDto.CreateDate,
                IsActive = menuCreateDto.IsActive,
                Drinks = menuCreateDto.Drinks,
                Eats = menuCreateDto.Eats,
                Extras = menuCreateDto.Extras,
                ImagePath = menuCreateDto.ImagePath,
            };
            return await menuRepository.Create(menu);
        }

        public async Task<bool> MenuDelete(int menuId)
        {
            Menu menu = await menuRepository.GetById(menuId);
            return await menuRepository.Delete(menu);
        }

        public async Task<IEnumerable<MenuListDto>> MenuList(Expression<Func<Menu, bool>> filter = null)
        {
            IEnumerable<Menu> menuList = await menuRepository.GetFilteredAll(filter);
            List<MenuListDto> menus = menuList.Select(x => new MenuListDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImagePath = x.ImagePath,

            }).ToList();
            return menus;
        }

        public async Task<bool> MenuUpdate(MenuUpdateDto menuUpdateDto)
        {
            Menu menu = await menuRepository.GetById(menuUpdateDto.Id);
            menu.Name = menuUpdateDto.Name;
            menu.Price = menuUpdateDto.Price;
            menu.UpdateDate = menuUpdateDto.UpdateDate;
            menu.Drinks = menuUpdateDto.Drinks;
            menu.Eats = menuUpdateDto.Eats;
            menu.Extras = menuUpdateDto.Extras;

            return await menuRepository.Update(menu);
        }
    }
}
