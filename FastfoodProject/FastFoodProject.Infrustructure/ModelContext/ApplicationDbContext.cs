using FastFoodProject.Domain.Entities;
using FastFoodProject.Domain.Entities.FoodEntities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FastFoodProject.Infrustructure.ModelContext
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public const string ConnectionString = "ApplicationDbConnection";
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Drink> Drinks { get; set; }
		public DbSet<Eat> Eats { get; set; }
		public DbSet<Extra> Extras { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<Drink>().HasData(
				new Drink
				{
					Id = 1,
					Name = "Cola",
					Price = 5,
					CreateDate = DateTime.Now,
					ImagePath = "~/img/Drinks/Cola.jpg",
					IsActive = true,
				},
				new Drink
				{
					Id = 2,
					Name = "Ice Tea",
					Price = 5,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath = "~/img/Drinks/IceTea.jpg",
				});
			builder.Entity<Eat>().HasData(
				new Eat
				{
					Id = 1,
					Name = "Beefy Burgers",
					Price = 12,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath = "~/img/burger/1.png",
				},
				new Eat
				{
					Id= 2,
					Name = "Burger Boys",
					Price = 8,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath = "~/img/burger/2.png",
				},
				new Eat
				{
					Id=3,
					Name = "Burger Bizz",
					Price = 7.66m,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath = "~/img/burger/3.png",
				},
				new Eat
				{
					Id = 4,
					Name = "Crackles Burger",
					Price = 12.45m,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath = "~/img/burger/4.png",
				});
			builder.Entity<Extra>().HasData(
				new Extra
				{
					Id = 1,
					Name = "Ketchup",
					Price = 0.50m,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath = "~/img/extras/Ketchup.jpg",
				},
				new Extra
				{	
					Id = 2,
					Name = "Mayonnaise",
					Price = 0.50m,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath = "~/img/extras/mayonnaise.jpg"
				},
				new Extra
				{
					Id = 3,
					Name = "BBQ",
					Price = 0.75m,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath = "~/img/extras/bbq.jpg"
				},
				new Extra
				{
					Id = 4,
					Name = "Chili Sauce",
					Price = 0.50m,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath = "~/img/extras/chilisauce.jpg"
				});
			builder.Entity<Menu>().HasData(
				new Menu
				{
					Id = 1,
					Name="Beefy Burgers Menu",
					Price=27.99m,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath= "~/img/Menus/1.jpg",
						
				},
				new Menu
				{
					Id = 2,
					Name= "Burger Boys Menu",
					Price =25.45m,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath = "~/img/Menus/2.jpg",
									
				},
				new Menu
				{
					Id = 3,
					Name= "Burger Bizz Menu",
					Price=32.60m,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath= "~/img/Menus/3.jpg",
					
				},
				new Menu
				{
					Id = 4,
					Name="Crackles Burger Menu",
					Price=37.78m,
					IsActive = true,
					CreateDate = DateTime.Now,
					ImagePath= "~/img/Menus/4.jpg",
					
				});
		}
	}
}
