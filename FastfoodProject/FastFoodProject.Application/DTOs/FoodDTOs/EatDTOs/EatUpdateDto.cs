namespace FastFoodProject.Application.DTOs.FoodDTOs.EatDTOs
{
	public class EatUpdateDto : EatListDto
	{
		public DateTime UpdateDate => DateTime.Now;
	}
}
