using FastFoodProject.Application.DTOs.FoodDTOs.ExtraDTOs;

namespace FastFoodProject.Presentation.ViewModels.FoodsVms.ExtraVms
{
	public class ExtraDetailVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string ImagePath { get; set; }
		public bool ?IsActive { get; set; }

	}
}
