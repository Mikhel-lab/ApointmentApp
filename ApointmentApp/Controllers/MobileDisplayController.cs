using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApointmentApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApointmentApp.Controllers
{
	public class MobileDisplayController : Controller
	{
		MobileContext MCon = new MobileContext();
		public IActionResult Index()
		{
			MobileData MD = new MobileData();
			MD.MobileList = new SelectList(MCon.GetMobileDatas(), "MobileId", "MobileName");
			return View();
		}
	}
}
