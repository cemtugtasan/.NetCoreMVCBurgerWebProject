namespace FastFoodProject.Domain.Entities.FoodEntities
{
	public class Drink:FoodBaseEntity
	{
		public ICollection<Order>? Orders { get; set; } = new HashSet<Order>();
		public ICollection<Menu>? Menus { get; set; } = new HashSet<Menu>();
		public DrinkSize DrinkSize { get; set; }
	}
	
	public enum DrinkSize
	{
		Small,
		Medium,
		Large,
	}
}
