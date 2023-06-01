namespace FastFoodProject.Application.DTOs.FoodDTOs.ExtraDTOs
{
	public class ExtraCreateDto
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public DateTime CreateDate => DateTime.Now;
		public bool IsActive => true;
		public string ImagePath { get; set; }
	}
}
