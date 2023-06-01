namespace FastFoodProject.Application.DTOs.FoodDTOs.MenuDTOs
{
	public class MenuUpdateDto:MenuListDto
	{
		public DateTime UpdateDate => DateTime.Now;
	}
}
