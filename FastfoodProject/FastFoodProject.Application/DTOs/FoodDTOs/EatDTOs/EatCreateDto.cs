namespace FastFoodProject.Application.DTOs.FoodDTOs.EatDTOs
{
	public class EatCreateDto
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public DateTime CreateDate => DateTime.Now;
		public bool IsActive => true;
		public string ImagePath { get; set; }
	}
}
