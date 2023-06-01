using FastFoodProject.Presentation.Models;
using FastFoodProject.Presentation.Models.Authentication.SignIn;
using FastFoodProject.Presentation.Models.Authentication.SignUp;
using FastFoodProject.Presentation.ViewModels.MembersVms.UserVms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace FastFoodProject.Presentation.Controllers
{
	public class HomeController : Controller
	{
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public HomeController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_signInManager= signInManager;
		}

		[Route("")]
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult SignIn()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn(SignInAppUser appUser)
		{
			IActionResult viewResult;

			var userByName = await _userManager.FindByNameAsync(appUser.Username);

			if (userByName != null)
			{

				if (await _userManager.CheckPasswordAsync(userByName, appUser.Password))
				{
					IdentityUser user = await _userManager.FindByNameAsync(appUser.Username);
					await _signInManager.SignOutAsync();					

					if (await _userManager.CheckPasswordAsync(userByName, appUser.Password))
					{
						await _signInManager.SignInAsync(user, false);
						var roles = await _userManager.GetRolesAsync(user);
						if (roles[0] == "USER")
						{
							viewResult = RedirectToAction("Index", "User", new { area = "User" });
						}
						else
						{
							viewResult = RedirectToAction("Index", "Admin");
						}
					}
					else
					{
						return StatusCode(StatusCodes.Status403Forbidden, "Kullanıcı Adı Ya Da şifre hatalı");
					}
				}
				else
				{
					viewResult = StatusCode(StatusCodes.Status406NotAcceptable, new AppResponse() { Status = "PAROLA HATASI!", Message = "Girilen parola hatalıdır!" });
				}
			}
			else
			{
				viewResult = StatusCode(StatusCodes.Status406NotAcceptable, new AppResponse() { Status = "KULLANICI ADI HATASI!", Message = "Sistemde böyle bir kullanıcı adı bulunmamaktadır!" });
			}


			return viewResult;
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp([FromForm] SignUpAppUser appUser, string role = "USER")
		{
			IActionResult viewResult = null;

			var userByName = await _userManager.FindByNameAsync(appUser.Username);
			if (userByName != null)
			{
				viewResult = StatusCode(StatusCodes.Status400BadRequest, new AppResponse() { Status = "HATA OLUŞTU!", Message = "Bu username sahip kullanıcı sistemde bulunmaktadır!" });
			}
			else
			{
				var userRole = await _roleManager.FindByNameAsync(role);
				if (userRole != null)
				{
					IdentityUser eklenecekKullanici = new()
					{
						UserName = appUser.Username,
						Email="",
						SecurityStamp = Guid.NewGuid().ToString()
					};

					var eklemeSonucu = await _userManager.CreateAsync(eklenecekKullanici, appUser.Password);

					if (eklemeSonucu.Succeeded)
					{
						await _userManager.AddToRoleAsync(eklenecekKullanici, role);

						viewResult = RedirectToAction("Index");
					}
					else
					{
						viewResult = StatusCode(StatusCodes.Status500InternalServerError, new AppResponse() { Status = "HATA OLUŞTU!", Message = "Kullanıcı sisteme kayıt edilirken sunucuda hata oluştu!" });
					}
				}
				else
				{
					viewResult = StatusCode(StatusCodes.Status400BadRequest, new AppResponse() { Status = "HATA OLUŞTU!", Message = "Uygulamada böyle bir kullanıcı rolü bulunmamaktadır!" });
				}
			}

			return viewResult;
		}
		
	}
}