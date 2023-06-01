using FastFoodProject.Domain.Entities.FoodEntities;

namespace FastFoodProject.Application.DTOs.FoodDTOs.MenuDTOs
{
	public class MenuCreateDto
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public DateTime CreateDate => DateTime.Now;
		public bool IsActive => true;
		public string ImagePath { get; set; }
		public virtual ICollection<Eat> Eats { get; set; }
		public virtual ICollection<Drink> Drinks { get; set; }
		public virtual ICollection<Extra> Extras { get; set; }
		public MenuCreateDto()
		{
			this.Eats = new HashSet<Eat>();
			this.Drinks = new HashSet<Drink>();
			this.Extras = new HashSet<Extra>();
		}
	}
}
