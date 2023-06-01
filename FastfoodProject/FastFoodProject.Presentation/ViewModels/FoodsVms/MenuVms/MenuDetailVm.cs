using FastFoodProject.Application.DTOs.FoodDTOs.MenuDTOs;
using FastFoodProject.Domain.Entities.FoodEntities;

namespace FastFoodProject.Presentation.ViewModels.FoodsVms.MenuVms
{
	public class MenuDetailVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public DateTime CreateDate {get; set;}
		public bool ?IsActive { get; set; }
		public string ImagePath { get; set; }
		public virtual ICollection<Eat> Eats { get; set; }
		public virtual ICollection<Drink> Drinks { get; set; }
		public virtual ICollection<Extra> Extras { get; set; }
		public MenuDetailVm()
		{
			Eats=new HashSet<Eat>();
			Drinks=new HashSet<Drink>();
			Extras=new HashSet<Extra>();
		}
	}
}
