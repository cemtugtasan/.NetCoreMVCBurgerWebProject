﻿namespace FastFoodProject.Domain.Entities.FoodEntities
{
	public class Eat : FoodBaseEntity
	{
		public ICollection<Order>? Orders { get; set; } = new HashSet<Order>();
		public ICollection<Menu>? Menus { get; set; } = new HashSet<Menu>();
	}
}
