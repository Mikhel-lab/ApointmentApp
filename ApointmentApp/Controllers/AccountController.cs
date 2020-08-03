using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApointmentApp.Models;
using ApointmentApp.ViewModels;
using CodebitCollegeEFC.AccountRepo;
using CodebitCollegeEFC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

namespace CodebitCollegeEFC.Controllers
{
	public class AccountController : Controller
	{
		//Adding properties
		private readonly IAccount _account;

		

		public IActionResult Index()
		{
			return View();
		}


		//Adding constructor
		public AccountController(IAccount account)
		{
			_account = account;
		}

	

		public IActionResult List()
		{
			return View(_account.Systems);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(SystemUsers systemUsers)
		{
			if (ModelState.IsValid)
			{
				_account.AddSystemUsers(systemUsers);
				return View("Thank", systemUsers);
			}
			else
			{
				return View();
			}
		}

		public IActionResult Details(int Id)
		{
			var person = _account.GetEmployee(Id);
			return View(person);
		}


		[HttpGet]
		public IActionResult Edit(int Id)
		{
			var person = _account.GetEmployee(Id);

			return View(person);
		}

		[HttpPost]
		public IActionResult Edit(SystemUsers systemUsers)
		{
			_account.EditSystemUsers(systemUsers);
			return View();
		}

		public IActionResult DeleteConfirm(int Id)
		{
			SystemUsers person = _account.GetEmployee(Id);
			if (person == null)
			{
				return RedirectToAction("List");
			}
			return View(person);
		}

		[HttpPost]
		public IActionResult Delete(int Id)
		{
			var person = _account.Delete(Id);
			return View("Deleted", person);
		}

	

	}
}
