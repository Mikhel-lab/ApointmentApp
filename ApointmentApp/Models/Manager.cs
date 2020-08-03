using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApointmentApp.Models
{
	public class Manager
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Date { get; set; }
		public string Priority { get; set; }
	}
}
