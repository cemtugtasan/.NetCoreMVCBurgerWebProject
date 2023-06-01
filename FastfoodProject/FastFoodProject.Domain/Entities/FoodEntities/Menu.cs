namespace FastFoodProject.Domain.Entities.FoodEntities
{
	public class Menu : FoodBaseEntity
	{
		public ICollection<Order>? Orders { get; set; } = new HashSet<Order>();
		public virtual ICollection<Eat>? Eats { get; set; }
		public virtual ICollection<Drink>? Drinks { get; set; }
		public virtual ICollection<Extra>? Extras { get; set; }
		public MenuSize MenuSize { get; set; }

		public Menu()
		{
			this.Eats = new HashSet<Eat>();
			this.Drinks = new HashSet<Drink>();
			this.Extras = new HashSet<Extra>();
		}
	}

	public enum MenuSize
	{
		Small,
		Medium,
		Large,
	}
}
