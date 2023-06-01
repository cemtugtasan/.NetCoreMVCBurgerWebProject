namespace FastFoodProject.Domain.Entities.FoodEntities
{
	public abstract class FoodBaseEntity : GeneralBaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string ImagePath { get; set; }
	}
}
