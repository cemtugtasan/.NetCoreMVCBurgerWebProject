using FastFoodProject.Domain.Entities;
using FastFoodProject.Domain.Entities.FoodEntities;
using FastFoodProject.Domain.IRepositories.IFoodRepositories;
using FastFoodProject.Infrustructure.ModelContext;
using FastFoodProject.Infrustructure.Repositories.FoodRepositories;
using FastFoodProject.Presentation.Areas.Admin.Models;
using FastFoodProject.Presentation.ViewModels.OrderVms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FastFoodProject.Presentation.Areas.User.Controllers
{
	[Authorize(Roles = "USER")]
	[Area("User")]
	public class UserController : Controller
	{
		private readonly DrinkRepository drinkRepository;
		private readonly EatRepository eatRepository;
		private readonly ExtraRepository extraRepository;
		private readonly MenuRepository MenuRepository;

		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IDrinkRepository _drinkRepository;
		private readonly IEatRepository _EatRepository;
		private readonly IExtraRepository _extraRepository;
		private readonly IMenuRepository _MenuRepository;

		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		private static AllPropertyInOne AllPropertyInOne = new AllPropertyInOne();
		public UserController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext applicationDbContext, SignInManager<IdentityUser> signInManager, IWebHostEnvironment webHostEnvironment, IDrinkRepository drinkRepository,
			IEatRepository eatRepository, IExtraRepository extraRepository, IMenuRepository menuRepository)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_context = applicationDbContext;
			_signInManager = signInManager;
			_webHostEnvironment = webHostEnvironment;
			_drinkRepository = drinkRepository;
			_extraRepository = extraRepository;
			_EatRepository = eatRepository;
			_extraRepository = extraRepository;
			_MenuRepository = menuRepository;

			AllPropertyInOne.menus.Clear();
			AllPropertyInOne.drinks.Clear();
			AllPropertyInOne.eats.Clear();
			AllPropertyInOne.extras.Clear();


			foreach (Menu menu1 in _context.Menus)
			{
				AllPropertyInOne.menus.Add(menu1);
			}
			foreach (Drink drink1 in _context.Drinks)
			{
				AllPropertyInOne.drinks.Add(drink1);
			}
			foreach (Extra extra1 in _context.Extras)
			{
				AllPropertyInOne.extras.Add(extra1);
			}
			foreach (Eat eat1 in _context.Eats)
			{
				AllPropertyInOne.eats.Add(eat1);
			}

		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Menu()
		{
			return View(AllPropertyInOne);
		}
		public async Task<IActionResult> AddEatsToOrder(int Id)
		{
			var eat = await _EatRepository.GetById(Id);
			AllPropertyInOne.order.Eats.Add(eat);
			return RedirectToAction("Menu");
		}
		public async Task<IActionResult> AddExtrasToOrder(int Id)
		{
			var extra = await _extraRepository.GetById(Id);
			AllPropertyInOne.order.Extras.Add(extra);
			return RedirectToAction("Menu");
		}
		public async Task<IActionResult> AddMenusToOrder(int Id)
		{
			var menu = await _MenuRepository.GetById(Id);
			AllPropertyInOne.order.Menus.Add(menu);
			return RedirectToAction("Menu");
		}
		public async Task<IActionResult> AddDrinkToOrder(int Id, string size)
		{
			var drink = await _drinkRepository.GetById(Id);
			if (size == "Small")
			{
				drink.DrinkSize = DrinkSize.Small;
			}
			else if (size == "Medium")
			{
				drink.DrinkSize = DrinkSize.Medium;
			}
			else
			{
				drink.DrinkSize = DrinkSize.Large;
			}
			AllPropertyInOne.order.Drinks.Add(drink);
			return RedirectToAction("Menu");
		}
		public IActionResult DeleteEatsToOrder(int Id)
		{
			Eat eat = AllPropertyInOne.order.Eats.Where(x => x.Id == Id).FirstOrDefault();
			AllPropertyInOne.order.Eats.Remove(eat);
			return RedirectToAction("Menu");
		}
		public async Task<IActionResult> DeleteExtrasToOrder(int Id)
		{
			Extra extra = AllPropertyInOne.order.Extras.Where(x => x.Id == Id).FirstOrDefault();
			AllPropertyInOne.order.Extras.Remove(extra);
			return RedirectToAction("Menu");
		}
		public async Task<IActionResult> DeleteMenusToOrder(int Id)
		{
			Menu menu = AllPropertyInOne.order.Menus.Where(x => x.Id == Id).FirstOrDefault();
			AllPropertyInOne.order.Menus.Remove(menu);
			return RedirectToAction("Menu");
		}
		public async Task<IActionResult> DeleteDrinksToOrder(int Id)
		{
			Drink drink = AllPropertyInOne.order.Drinks.Where(x => x.Id == Id).FirstOrDefault();
			AllPropertyInOne.order.Drinks.Remove(drink);
			return RedirectToAction("Menu");
		}
		public async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
		public async Task<IActionResult> CreateOrder()
		{			
			Order order = new Order();
			order.CreateDate = DateTime.Now;
			foreach (Eat eat in AllPropertyInOne.eats)
			{
				order.Eats.Add(_context.Eats.Find(eat.Id));
			}
			foreach (Drink drink in AllPropertyInOne.drinks)
			{
				order.Drinks.Add(_context.Drinks.Find(drink.Id));
			}
			foreach (Extra extra in AllPropertyInOne.extras)
			{
				order.Extras.Add(_context.Extras.Find(extra.Id));
			}
			foreach (Menu menu in AllPropertyInOne.menus)
			{
				order.Menus.Add(_context.Menus.Find(menu.Id));
			}
			if (AllPropertyInOne.order.Eats.Count > 0 || AllPropertyInOne.order.Drinks.Count > 0 || AllPropertyInOne.order.Extras.Count > 0 || AllPropertyInOne.order.Menus.Count > 0)
			{

				await _context.Orders.AddAsync(order);
				await _context.SaveChangesAsync();
				AllPropertyInOne.order.Drinks.Clear();
				AllPropertyInOne.order.Eats.Clear();
				AllPropertyInOne.order.Extras.Clear();
				AllPropertyInOne.order.Menus.Clear();

				return RedirectToAction("Index", "User");
			}
			else
			{
				return StatusCode(StatusCodes.Status403Forbidden, "Sipariş Kısmı Boş Olamaz");
			}



		}
	}
}
