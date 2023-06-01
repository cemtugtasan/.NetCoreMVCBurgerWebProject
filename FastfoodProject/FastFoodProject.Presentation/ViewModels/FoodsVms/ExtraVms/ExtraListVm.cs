using FastFoodProject.Application.DTOs.FoodDTOs.ExtraDTOs;

namespace FastFoodProject.Presentation.ViewModels.FoodsVms.ExtraVms
{
	public class ExtraListVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string ImagePath { get; set; }

		public ExtraListVm(ExtraListDto extraListDto)
		{
			Id = extraListDto.Id;
			Name = extraListDto.Name;
			Price = extraListDto.Price;
			ImagePath = extraListDto.ImagePath;
		}
	}
}
