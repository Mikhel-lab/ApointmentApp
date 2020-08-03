using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApointmentApp.ManagerRepo;
using ApointmentApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ApointmentApp.Controllers
{
	public class ManagerController : Controller
	{
		//Adding properties
		private readonly IManager _manager;
		public IActionResult Index()
		{
			return View();
		}


		//Adding constructor
		public ManagerController(IManager man)
		{
			_manager = man;
		}

		public IActionResult List()
		{
			return View(_manager.Managers);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Manager manager)
		{
			if (ModelState.IsValid)
			{
				_manager.AddManager(manager);
				return View("Thank", manager);
			}
			else
			{
				return View();
			}
		}

		public IActionResult Details(int Id)
		{
			var person = _manager.GetEmployee(Id);
			return View(person);
		}


		[HttpGet]
		public IActionResult Edit(int Id)
		{
			var person = _manager.GetEmployee(Id);
			
			return View(person);
		}

		[HttpPost]
		public IActionResult Edit(Manager manager)
		{
			 _manager.EditManager(manager);
			return View();
		}

		public IActionResult DeleteConfirm(int Id)
		{
			Manager person = _manager.GetEmployee(Id);
			if (person == null)
			{
				return RedirectToAction("List");
			}
			return View(person);
		}

		[HttpPost]
		public IActionResult Delete(int Id)
		{
			var person = _manager.Delete(Id);
			return View("Deleted", person);
		}
	}
}
