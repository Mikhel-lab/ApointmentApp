using ApointmentApp.Models;
using CodebitCollegeEFC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitCollegeEFC.AccountRepo
{
	public class AccountRepository : IAccount
	{
		//Add Datacontext properties
		private readonly DataContext context;

		//creating a aconstructor
		public AccountRepository(DataContext cont)
		{
			context = cont;
		}

		//List the managers
		public IEnumerable<SystemUsers> Systems
		{
			get
			{
				return context.SystemUsersTable;
			}
		}

		//Add Manager
		public void AddSystemUsers(SystemUsers systemUsers)
		{
			context.SystemUsersTable.Add(systemUsers);
			context.SaveChanges();
		}

		//Delete Manager
		public SystemUsers Delete(int Id)
		{
			SystemUsers systemUsers = context.SystemUsersTable.Find(Id);
			if (systemUsers != null)
			{
				context.SystemUsersTable.Remove(systemUsers);
				context.SaveChanges();
			}
			return systemUsers;
		}

		public SystemUsers GetEmployee(int Id)
		{
			return context.SystemUsersTable.Find(Id);
		}

		public void EditSystemUsers(SystemUsers systemUsers)
		{
			context.Entry(systemUsers).State = EntityState.Modified;
			context.SaveChanges();
		}
	}
}
