namespace FastFoodProject.Application.DTOs.FoodDTOs.DrinkDTOs
{
	public class DrinkCreateDto
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public DateTime CreateDate => DateTime.Now;
		public bool IsActive => true;
		public string ImagePath { get; set; }
	}
}
