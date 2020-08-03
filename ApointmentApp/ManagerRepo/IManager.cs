using ApointmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApointmentApp.ManagerRepo
{
	public interface IManager
	{
		IEnumerable<Manager> Managers { get; }
		public void AddManager(Manager manager);
		Manager Delete(int Id);
		Manager GetEmployee(int Id);

		public void EditManager(Manager manager);
	}
}
