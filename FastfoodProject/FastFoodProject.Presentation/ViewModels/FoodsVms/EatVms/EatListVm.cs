using FastFoodProject.Application.DTOs.FoodDTOs.EatDTOs;

namespace FastFoodProject.Presentation.ViewModels.FoodsVms.EatVms
{
	public class EatListVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string ImagePath { get; set; }

		public EatListVm(EatListDto eatListDto)
		{
			Id= eatListDto.Id;
			Name= eatListDto.Name;
			Price= eatListDto.Price;
			ImagePath = eatListDto.ImagePath;
		}
	}
}
