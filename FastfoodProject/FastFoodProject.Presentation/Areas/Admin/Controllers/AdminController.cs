using FastFoodProject.Application.IServices.IMemberServices;
using FastFoodProject.Domain.Entities.FoodEntities;
using FastFoodProject.Domain.IRepositories.IFoodRepositories;
using FastFoodProject.Infrustructure.ModelContext;
using FastFoodProject.Infrustructure.Repositories.FoodRepositories;
using FastFoodProject.Presentation.Areas.Admin.Models;
using FastFoodProject.Presentation.ViewModels.FoodsVms.DrinkVms;
using FastFoodProject.Presentation.ViewModels.FoodsVms.EatVms;
using FastFoodProject.Presentation.ViewModels.FoodsVms.ExtraVms;
using FastFoodProject.Presentation.ViewModels.FoodsVms.MenuVms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Runtime.CompilerServices;

namespace FastFoodProject.Presentation.Areas.Admin.Controllers
{
	[Authorize(Roles = "ADMIN")]
	[Area("Admin")]
	public class AdminController : Controller
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
		public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext applicationDbContext, SignInManager<IdentityUser> signInManager, IWebHostEnvironment webHostEnvironment,IDrinkRepository drinkRepository,
			IEatRepository eatRepository,IExtraRepository extraRepository,IMenuRepository menuRepository)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_context = applicationDbContext;
			_signInManager = signInManager;			
			_webHostEnvironment= webHostEnvironment;
			_drinkRepository= drinkRepository;
			_extraRepository= extraRepository;
			_EatRepository = eatRepository;
			_extraRepository= extraRepository;
			_MenuRepository= menuRepository;

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
			return View(AllPropertyInOne);
		}
		public IActionResult CreateDrink()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateDrink(DrinkDetailVm drinkVm,IFormFile ImagePath)
		{
			string wwwRootPath = _webHostEnvironment.WebRootPath;
			if (ImagePath != null)
			{
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
				string productPath = Path.Combine(wwwRootPath, @"images\product\drinks\");
				
				using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
				{
					ImagePath.CopyTo(fileStream);
				}

				drinkVm.ImagePath = @"\images\product\drinks\" + fileName;
			}
			Drink drink = new Drink()
			{
				Name= drinkVm.Name,
				IsActive=true,
				CreateDate= DateTime.Now,
				ImagePath=drinkVm.ImagePath,
				Price=drinkVm.Price,			
			};
			 await _drinkRepository.Create(drink);
			 await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Admin");
		}
		public IActionResult CreateEat()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateEat(EatDetailVm eatVm, IFormFile ImagePath)
		{
			string wwwRootPath = _webHostEnvironment.WebRootPath;
			if (ImagePath != null)
			{
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
				string productPath = Path.Combine(wwwRootPath, @"images\product\eats\");

				using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
				{
					ImagePath.CopyTo(fileStream);
				}

				eatVm.ImagePath = @"\images\product\eats\" + fileName;
			}
			Eat eat = new Eat()
			{
				Name = eatVm.Name,
				IsActive = true,
				CreateDate = DateTime.Now,
				ImagePath = eatVm.ImagePath,
				Price = eatVm.Price,
			};
			await _EatRepository.Create(eat);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Admin");
		}
		public IActionResult CreateExtra()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateExtra(ExtraDetailVm extraVm, IFormFile ImagePath)
		{
			string wwwRootPath = _webHostEnvironment.WebRootPath;
			if (ImagePath != null)
			{
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
				string productPath = Path.Combine(wwwRootPath, @"images\product\extras\");

				using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
				{
					ImagePath.CopyTo(fileStream);
				}

				extraVm.ImagePath = @"\images\product\extras\" + fileName;
			}
			Extra extra = new Extra()
			{
				Name = extraVm.Name,
				IsActive = true,
				CreateDate = DateTime.Now,
				ImagePath = extraVm.ImagePath,
				Price = extraVm.Price,
			};
			await _extraRepository.Create(extra);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Admin");
		}
		public IActionResult CreateMenu()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateMenu(MenuDetailVm MenuVm, IFormFile ImagePath)
		{
			string wwwRootPath = _webHostEnvironment.WebRootPath;
			if (ImagePath != null)
			{
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
				string productPath = Path.Combine(wwwRootPath, @"images\product\Menus\");

				using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
				{
					ImagePath.CopyTo(fileStream);
				}

				MenuVm.ImagePath = @"\images\product\Menus\" + fileName;
			}
			Menu menu = new Menu()
			{
				Name = MenuVm.Name,
				IsActive = true,
				CreateDate = DateTime.Now,
				ImagePath = MenuVm.ImagePath,
				Price = MenuVm.Price,
			};
			await _MenuRepository.Create(menu);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Admin");
		}
		public async Task<IActionResult> EditDrink(int id)
		{
			Drink drink = await _drinkRepository.GetById(id);
			if (drink!= null)
			{
				DrinkDetailVm drinkDetailVm = new DrinkDetailVm()
				{
					Id= drink.Id,
					Name=drink.Name,
					Price=drink.Price,
					ImagePath=drink.ImagePath,
					IsActive=drink.IsActive,
				};
				return View(drinkDetailVm);
			}
			else
			{
				return RedirectToAction("index", "admin");
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditDrink(DrinkDetailVm drinkVm, IFormFile ImagePath)
		{
			Drink drink = await _context.Drinks.FindAsync(drinkVm.Id);
			if (drink !=null)
			{
				if (!string.IsNullOrEmpty(drink.Name))
				{
					drink.Name= drinkVm.Name;
				}
				else
				{
					ModelState.AddModelError("", "Name Cannot Be Empty!");
				}
				if (!string.IsNullOrEmpty(drinkVm.Price.ToString()))
				{
					drink.Price = drinkVm.Price;
				}
				else
				{
					ModelState.AddModelError("", "Price Is Not Available!");
				}
				if (!string.IsNullOrEmpty(drink.Name)&& !string.IsNullOrEmpty(drinkVm.Price.ToString()))
				{
					string wwwRootPath = _webHostEnvironment.WebRootPath;
					if (ImagePath != null)
					{
						string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
						string productPath = Path.Combine(wwwRootPath, @"images\product\drinks\");

						using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
						{
							ImagePath.CopyTo(fileStream);
						}

						drinkVm.ImagePath = @"\images\product\drinks\" + fileName;
					}
					else
					{
						return StatusCode(StatusCodes.Status403Forbidden, "Name or ");
					}					
					await _drinkRepository.Update(drink);
					
					if (await _drinkRepository.Update(drink))
					{
						await _context.SaveChangesAsync();
						return RedirectToAction("Index", "Admin");
					}
					else
					{
						return StatusCode(StatusCodes.Status403Forbidden, "Unknown problem!");
					}
				}
				else
				{
					return StatusCode(StatusCodes.Status403Forbidden, "Drink Name or Price can not be null!");
				}
			}
			else
			{
				return StatusCode(StatusCodes.Status403Forbidden, "Unknown Problem!");
			}
		}
		public async Task<IActionResult> EditEat(int id)
		{
			Eat eat = await _EatRepository.GetById(id);
			if (eat != null)
			{
				EatDetailVm eatDetailVm = new EatDetailVm()
				{
					Id = eat.Id,
					Name = eat.Name,
					Price = eat.Price,
					ImagePath = eat.ImagePath,
					IsActive = eat.IsActive
				};
				return View(eatDetailVm);
			}
			else
			{
				return RedirectToAction("index", "admin");
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditEat(EatDetailVm eatVm, IFormFile ImagePath)
		{
			Eat eat = await _context.Eats.FindAsync(eatVm.Id);
			if (eat != null)
			{
				if (!string.IsNullOrEmpty(eat.Name))
				{
					eat.Name = eatVm.Name;
				}
				else
				{
					ModelState.AddModelError("", "Name Cannot Be Empty!");
				}
				if (!string.IsNullOrEmpty(eatVm.Price.ToString()))
				{
					eat.Price = eatVm.Price;
				}
				else
				{
					ModelState.AddModelError("", "Price Is Not Available!");
				}
				if (!string.IsNullOrEmpty(eat.Name) && !string.IsNullOrEmpty(eatVm.Price.ToString()))
				{
					string wwwRootPath = _webHostEnvironment.WebRootPath;
					if (ImagePath != null)
					{
						string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
						string productPath = Path.Combine(wwwRootPath, @"images\product\eats\");

						using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
						{
							ImagePath.CopyTo(fileStream);
						}

						eatVm.ImagePath = @"\images\product\eats\" + fileName;
					}
					else
					{
						return StatusCode(StatusCodes.Status403Forbidden, "Name or ");
					}					
					await _EatRepository.Update(eat);
					if (await _EatRepository.Update(eat))
					{
						await _context.SaveChangesAsync();
						return RedirectToAction("Index", "Admin");
					}
					else
					{
						return StatusCode(StatusCodes.Status403Forbidden, "Unknown problem!");
					}
				}
				else
				{
					return StatusCode(StatusCodes.Status403Forbidden, "Drink Name or Price can not be null!");
				}
			}
			else
			{
				return StatusCode(StatusCodes.Status403Forbidden, "Unknown Problem!");
			}
		}
		public async Task<IActionResult> EditExtra(int id)
		{
			Extra extra = await _extraRepository.GetById(id);
			if (extra != null)
			{
				ExtraDetailVm extraDetailVm = new ExtraDetailVm()
				{
					Id = extra.Id,
					Name = extra.Name,
					Price = extra.Price,
					ImagePath = extra.ImagePath,
					IsActive = extra.IsActive
				};
				return View(extraDetailVm);
			}
			else
			{
				return RedirectToAction("index", "admin");
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditExtra(ExtraDetailVm extraVm, IFormFile ImagePath)
		{
			Extra extra = await _context.Extras.FindAsync(extraVm.Id);
			if (extra != null)
			{
				if (!string.IsNullOrEmpty(extra.Name))
				{
					extra.Name = extraVm.Name;
				}
				else
				{
					ModelState.AddModelError("", "Name Cannot Be Empty!");
				}
				if (!string.IsNullOrEmpty(extraVm.Price.ToString()))
				{
					extra.Price = extraVm.Price;
				}
				else
				{
					ModelState.AddModelError("", "Price Is Not Available!");
				}
				if (!string.IsNullOrEmpty(extra.Name) && !string.IsNullOrEmpty(extraVm.Price.ToString()))
				{
					string wwwRootPath = _webHostEnvironment.WebRootPath;
					if (ImagePath != null)
					{
						string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
						string productPath = Path.Combine(wwwRootPath, @"images\product\extras\");

						using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
						{
							ImagePath.CopyTo(fileStream);
						}

						extraVm.ImagePath = @"\images\product\extras\" + fileName;
					}
					else
					{
						return StatusCode(StatusCodes.Status403Forbidden, "ImagePath can not be empty! ");
					}
					await _extraRepository.Update(extra);
					if (await _extraRepository.Update(extra))
					{
						await _context.SaveChangesAsync();
						return RedirectToAction("Index", "Admin");
					}
					else
					{
						return StatusCode(StatusCodes.Status403Forbidden, "Unknown problem!");
					}
				}
				else
				{
					return StatusCode(StatusCodes.Status403Forbidden, "Drink Name or Price can not be null!");
				}
			}
			else
			{
				return StatusCode(StatusCodes.Status403Forbidden, "Unknown Problem!");
			}
		}
		public async Task<IActionResult> EditMenu(int id)
		{
			Menu menu = await _MenuRepository.GetById(id);
			if (menu != null)
			{
				MenuDetailVm menuDetailVm = new MenuDetailVm()
				{
					Id = menu.Id,
					Name = menu.Name,
					Price = menu.Price,
					ImagePath = menu.ImagePath,
					IsActive = menu.IsActive
				};
				return View(menuDetailVm);
			}
			else
			{
				return RedirectToAction("index", "admin");
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditMenu(MenuDetailVm menuVm, IFormFile ImagePath)
		{
			Menu menu = await _context.Menus.FindAsync(menuVm.Id);
			if (menu != null)
			{
				if (!string.IsNullOrEmpty(menu.Name))
				{
					menu.Name = menuVm.Name;
				}
				else
				{
					ModelState.AddModelError("", "Name Cannot Be Empty!");
				}
				if (!string.IsNullOrEmpty(menuVm.Price.ToString()))
				{
					menu.Price = menuVm.Price;
				}
				else
				{
					ModelState.AddModelError("", "Price Is Not Available!");
				}
				if (!string.IsNullOrEmpty(menu.Name) && !string.IsNullOrEmpty(menuVm.Price.ToString()))
				{
					string wwwRootPath = _webHostEnvironment.WebRootPath;
					if (ImagePath != null)
					{
						string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
						string productPath = Path.Combine(wwwRootPath, @"images\product\Menus\");

						using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
						{
							ImagePath.CopyTo(fileStream);
						}

						menuVm.ImagePath = @"\images\product\Menus\" + fileName;
					}
					else
					{
						return StatusCode(StatusCodes.Status403Forbidden, "Name or ");
					}
					await _MenuRepository.Update(menu);
					if (await _MenuRepository.Update(menu))
					{
						await _context.SaveChangesAsync();
						return RedirectToAction("Index", "Admin");
					}
					else
					{
						return StatusCode(StatusCodes.Status403Forbidden, "Unknown problem!");
					}
				}
				else
				{
					return StatusCode(StatusCodes.Status403Forbidden, "Drink Name or Price can not be null!");
				}
			}
			else
			{
				return StatusCode(StatusCodes.Status403Forbidden, "Unknown Problem!");
			}
		}
		public async Task<IActionResult> DeleteDrink(int id)
		{
			Drink drink = await _drinkRepository.GetById(id);
			_context.Drinks.Remove(drink);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "Admin");
		}
		public async Task<IActionResult> DeleteEat(int id)
		{
			Eat eat = await _EatRepository.GetById(id);
			_context.Eats.Remove(eat);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "Admin");
		}
		public async Task<IActionResult> DeleteExtra(int id)
		{
			Extra extra = await _extraRepository.GetById(id);
			_context.Extras.Remove(extra);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "Admin");
		}
		public async Task<IActionResult> DeleteMenu(int id)
		{
			Menu menu = await _MenuRepository.GetById(id);
			_context.Menus.Remove(menu);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "Admin");
		}
		public async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
