using ApointmentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApointmentApp.ManagerRepo
{
	public class ManagerRepository : IManager
	{
		//Add Datacontext properties
		private readonly DataContext context;

		//creating a aconstructor
		public ManagerRepository(DataContext cont)
		{
			context = cont;
		}

		//List the managers
		public IEnumerable<Manager> Managers
		{
			get
			{
				return context.ManagersTable;
			}
		}

		//Add Manager
		public void AddManager(Manager manager)
		{
			context.ManagersTable.Add(manager);
			context.SaveChanges();
		}

		//Delete Manager
		public Manager Delete(int Id)
		{
			Manager manager = context.ManagersTable.Find(Id);
			if (manager != null)
			{
				context.ManagersTable.Remove(manager);
				context.SaveChanges();
			}
			return manager;
		}

		public Manager GetEmployee(int Id)
		{
			return context.ManagersTable.Find(Id);
		}

		public void EditManager(Manager manager)
		{
			context.Entry(manager).State = EntityState.Modified;
			context.SaveChanges();
		}
	}
}
