using FastFoodProject.Application.DTOs.FoodDTOs.DrinkDTOs;

namespace FastFoodProject.Presentation.ViewModels.FoodsVms.DrinkVms
{
	public class DrinkListVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string ImagePath { get; set; }
		public DrinkListVm(DrinkListDto drinkListDto)
		{
			Id = drinkListDto.Id;
			Name= drinkListDto.Name;
			Price= drinkListDto.Price;
			ImagePath= drinkListDto.ImagePath;
		}
	}
}
