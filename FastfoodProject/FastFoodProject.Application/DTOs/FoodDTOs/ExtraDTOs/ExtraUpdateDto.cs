namespace FastFoodProject.Application.DTOs.FoodDTOs.ExtraDTOs
{
	public class ExtraUpdateDto:ExtraListDto
	{
		public DateTime UpdateDate => DateTime.Now;
	}
}
