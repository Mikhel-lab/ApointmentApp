using CodebitCollegeEFC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitCollegeEFC.AccountRepo
{
	public interface IAccount
	{
		IEnumerable<SystemUsers> Systems { get; }
		public void AddSystemUsers(SystemUsers systemUsers);
		SystemUsers Delete(int Id);
		SystemUsers GetEmployee(int Id);

		public void EditSystemUsers(SystemUsers systemUsers);
	}
}
