using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApointmentApp.LoginRepo;
using ApointmentApp.ViewModels;
using CodebitCollegeEFC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApointmentApp.Controllers
{
	public class LoginController : Controller
	{

		private readonly IRegisterAccount _register;

		public SignInManager<IdentityUser> signInManager { get; }
		public UserManager<IdentityUser> userManager { get; }

		public LoginController(IRegisterAccount reg, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
		{
			_register = reg;
			this.signInManager = signInManager;
			this.userManager = userManager;
		}


		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		public IActionResult List()
		{
			return View(_register.RegisterViews);
		}


		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(RegisterViewModel registerView)
		{
			if (ModelState.IsValid)
			{
				_register.AddRegisterViews(registerView);
				return View("Thank", registerView);
			}
			else
			{
				return View();
			}
		}

		public IActionResult Details(int Id)
		{
			var person = _register.GetRegisterViews(Id);
			return View(person);
		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			var person = _register.GetRegisterViews(Id);

			return View(person);
		}

		[HttpPost]
		public IActionResult Edit(RegisterViewModel registerView)
		{
			_register.EditRegisterViews(registerView);
			return View();
		}

		public IActionResult DeleteConfirm(int Id)
		{
			RegisterViewModel person = _register.GetRegisterViews(Id);
			if (person == null)
			{
				return RedirectToAction("List");
			}
			return View(person);
		}

		[HttpPost]
		public IActionResult Delete(int Id)
		{
			var person = _register.Delete(Id);
			return View("Deleted", person);
		}




		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new IdentityUser { UserName = model.Email, Email = model.Email };
				var result = await userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
				  await	signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("List", "Login");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{

			if (ModelState.IsValid)
			{
				HttpContext.Session.SetString("Email", model.Email);
				ViewBag.Message = HttpContext.Session.GetString("Email");
				var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
				if (result.Succeeded)
				{

					return RedirectToAction("index");
				}

				ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
			}
			return View(model);
		}

		public IActionResult Index()
		{
			return View();
		}

		//[HttpGet]
		//public IActionResult Login()
		//{
		//	return View();
		//}

		//[HttpPost]
		//public IActionResult Login(LoginViewModel model)
		//{
		//	var ans = _register.Login(model.Email, model.Password);

		//	if (ans == true)
		//	{
		//		return View("Index", ans);
		//	}
		//	else
		//	{
		//		ViewBag.ErrorMessage = "Invalid username or password";
		//		return View();
		//	}


		//}

		[HttpGet]
		public IActionResult LoginUser( )
		{
			
			return View();
		}


		[HttpPost]
		public IActionResult LoginUser(RegisterViewModel model)
		{
			//var m = _register.Authentication(model.Username, model.Password);

			var flag = _register.Authentication(model.Username, model.Password);
			if (flag)
			{
				return View("Index");
			}
			else
			{
				return View(model);
			}
			
		}
		
	}
}
