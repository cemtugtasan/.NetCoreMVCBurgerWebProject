using FastFoodProject.Domain.Entities.FoodEntities;

namespace FastFoodProject.Application.DTOs.OrderDTOs
{
	public class OrderUpdateDto:OrderListDto
	{
		public DateTime UpdateDate => DateTime.Now;
		public OrderUpdateDto()
		{
			this.Eats = new HashSet<Eat>();
			this.Drinks = new HashSet<Drink>();
			this.Extras = new HashSet<Extra>();
			this.Menus = new HashSet<Menu>();
		}
	}
}
