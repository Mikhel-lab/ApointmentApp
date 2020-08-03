using ApointmentApp.Models;
using ApointmentApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApointmentApp.LoginRepo
{
	public class RegisterAccountRepository : IRegisterAccount
	{
		//Add Datacontext properties
		private readonly DataContext context;

		//creating a aconstructor
		public RegisterAccountRepository(DataContext cont)
		{
			context = cont;
		}

		//List the managers
		public IEnumerable<RegisterViewModel> RegisterViews
		{
			get
			{
				return context.RegistersViewTable;
			}
		}

		//Add Manager
		public void AddRegisterViews(RegisterViewModel registerView)
		{
			context.RegistersViewTable.Add(registerView);
			context.SaveChanges();
		}

		//Delete Manager
		public RegisterViewModel Delete(int Id)
		{
			RegisterViewModel registerView = context.RegistersViewTable.Find(Id);
			if (registerView != null)
			{
				context.RegistersViewTable.Remove(registerView);
				context.SaveChanges();
			}
			return registerView;
		}

		public RegisterViewModel GetRegisterViews(int Id)
		{
			return context.RegistersViewTable.Find(Id);
		}

		public void EditRegisterViews(RegisterViewModel registerView)
		{
			context.Entry(registerView).State = EntityState.Modified;
			context.SaveChanges();
		}

		public bool Authentication(string u, string p)
		{
			//var result = context.RegistersViewTable.Where(last => last.Username.Contains(registerView.Username) && last.Password.Contains(registerView.Password));
			var result = context.RegistersViewTable.Where(last => last.Username.Contains(u) && last.Password.Contains(p));
			if (result.Count() > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
			
		}
	}
}
