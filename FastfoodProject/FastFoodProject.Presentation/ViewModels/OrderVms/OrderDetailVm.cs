using FastFoodProject.Application.DTOs.OrderDTOs;
using FastFoodProject.Domain.Entities.FoodEntities;

namespace FastFoodProject.Presentation.ViewModels.OrderVms
{
	public class OrderDetailVm
	{
		public string Name { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime CreateDate { get; set; }
		public bool ?IsActive {get; set; }
		public virtual ICollection<Eat> Eats { get; set; }
		public virtual ICollection<Drink> Drinks { get; set; }
		public virtual ICollection<Extra> Extras { get; set; }
		public virtual ICollection<Menu> Menus { get; set; }

		public OrderDetailVm()
		{
			Eats=new List<Eat>();
			Drinks=new List<Drink>();
			Extras=new List<Extra>();
			Menus=new List<Menu>();
			
		}
	}
}
