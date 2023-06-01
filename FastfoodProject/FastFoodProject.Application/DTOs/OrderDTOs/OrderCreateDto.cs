using FastFoodProject.Domain.Entities.FoodEntities;

namespace FastFoodProject.Application.DTOs.OrderDTOs
{
	public class OrderCreateDto
	{
		public string Name { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime CreateDate => DateTime.Now;
		public bool IsActive => true;
		public virtual ICollection<Eat> Eats { get; set; }
		public virtual ICollection<Drink> Drinks { get; set; }
		public virtual ICollection<Extra> Extras { get; set; }
		public virtual ICollection<Menu> Menus { get; set; }

		public OrderCreateDto()
		{
			this.Eats = new HashSet<Eat>();
			this.Drinks = new HashSet<Drink>();
			this.Extras = new HashSet<Extra>();
			this.Menus = new HashSet<Menu>();
		}
	}
}
