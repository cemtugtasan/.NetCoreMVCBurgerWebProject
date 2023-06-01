using FastFoodProject.Application.DTOs.OrderDTOs;
using FastFoodProject.Domain.Entities.FoodEntities;

namespace FastFoodProject.Presentation.ViewModels.OrderVms
{
	public class OrderListVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal TotalPrice { get; set; }
		public virtual ICollection<Eat> Eats { get; set; }
		public virtual ICollection<Drink> Drinks { get; set; }
		public virtual ICollection<Extra> Extras { get; set; }
		public virtual ICollection<Menu> Menus { get; set; }

		public OrderListVm(OrderListDto orderListDto)
		{
			Eats = new List<Eat>();
			Drinks = new List<Drink>();
			Extras = new List<Extra>();
			Menus = new List<Menu>();
			Id = orderListDto.Id;
			Name = orderListDto.Name;
			TotalPrice = orderListDto.TotalPrice;
			Eats = orderListDto.Eats;
			Drinks = orderListDto.Drinks;
			Extras = orderListDto.Extras;
			Menus = orderListDto.Menus;
		}
	}
}
