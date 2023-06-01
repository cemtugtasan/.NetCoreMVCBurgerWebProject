using FastFoodProject.Domain.Entities.FoodEntities;

namespace FastFoodProject.Domain.Entities
{
	public class Order : GeneralBaseEntity
	{
		public int Id { get; set; }
		public string ?Name { get; set; }
		public decimal TotalPrice { get; set; }


		public virtual ICollection<Eat>? Eats { get; set; }
		public virtual ICollection<Drink>? Drinks { get; set; }
		public virtual ICollection<Extra>? Extras { get; set; }
		public virtual ICollection<Menu>? Menus { get; set; }

		public Order()
		{
			this.Eats = new HashSet<Eat>();
			this.Drinks = new HashSet<Drink>();
			this.Extras = new HashSet<Extra>();
			this.Menus = new HashSet<Menu>();
		}
	}
}
