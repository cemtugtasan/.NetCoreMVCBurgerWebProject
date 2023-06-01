using FastFoodProject.Domain.Entities;
using FastFoodProject.Domain.Entities.FoodEntities;

namespace FastFoodProject.Presentation.Areas.Admin.Models
{
	public class AllPropertyInOne
	{
		public List<Drink> drinks { get; set; } = new List<Drink>();
		public List<Eat> eats { get; set; } = new List<Eat>();
		public List<Extra> extras { get; set; } = new List<Extra>();
		public List<Menu> menus { get; set; } = new List<Menu>();
		public Order order { get; set; } = new Order();
	}
}
