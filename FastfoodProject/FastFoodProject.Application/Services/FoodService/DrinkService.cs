using FastFoodProject.Application.DTOs.FoodDTOs.DrinkDTOs;
using FastFoodProject.Application.IServices.IFoodServices;
using FastFoodProject.Domain.Entities.FoodEntities;
using FastFoodProject.Domain.IRepositories.IFoodRepositories;
using System.Linq.Expressions;

namespace FastFoodProject.Application.Services.FoodService
{
	public class DrinkService : IDrinkService
    {
        private readonly IDrinkRepository _repository;

        public DrinkService(IDrinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DrinkCreate(DrinkCreateDto drinkCreateDto)
        {
            Drink drink = new Drink
            {
                Name = drinkCreateDto.Name,
                Price = drinkCreateDto.Price,
                ImagePath = drinkCreateDto.ImagePath,
                CreateDate = drinkCreateDto.CreateDate,
                IsActive = drinkCreateDto.IsActive,
            };
            return await _repository.Create(drink);
        }

        public async Task<bool> DrinkDelete(int drinkId)
        {
            Drink drink = await _repository.GetById(drinkId);
            return await _repository.Delete(drink);
        }

        public async Task<IEnumerable<DrinkListDto>> DrinkList(Expression<Func<Drink, bool>> filter = null)
        {
            IEnumerable<Drink> drinkList = await _repository.GetFilteredAll(filter);
            List<DrinkListDto> drinks = drinkList.Select(x => new DrinkListDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImagePath = x.ImagePath
            }).ToList();
            return drinks;
        }

        public async Task<bool> DrinkUpdate(DrinkUpdateDto drinkUpdateDto)
        {
            Drink drink = await _repository.GetById(drinkUpdateDto.Id);
            drink.Name = drinkUpdateDto.Name;
            drink.Price = drinkUpdateDto.Price;
            drink.UpdateDate = drinkUpdateDto.UpdateDate;
            drink.ImagePath = drinkUpdateDto.ImagePath;
            return await _repository.Update(drink);
        }

        public async Task<DrinkCreateDto> GetByDrinkId(int drinkId)
        {
            Drink drink = await _repository.GetById(drinkId);

            DrinkCreateDto drinkCreateDto = new DrinkCreateDto
            {
                Name = drink.Name,
                Price = drink.Price,
                ImagePath = drink.ImagePath,
            };
            return drinkCreateDto;
        }
    }
}
