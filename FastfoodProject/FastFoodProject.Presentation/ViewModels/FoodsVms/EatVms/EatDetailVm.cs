using FastFoodProject.Application.DTOs.FoodDTOs.EatDTOs;

namespace FastFoodProject.Presentation.ViewModels.FoodsVms.EatVms
{
	public class EatDetailVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public DateTime CreateDate { get; set; }
		public string ImagePath { get; set; }
		public bool ?IsActive { get; set; }

	}
}
