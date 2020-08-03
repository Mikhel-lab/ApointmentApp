using ApointmentApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApointmentApp.LoginRepo
{
	public interface IRegisterAccount
	{
		IEnumerable<RegisterViewModel> RegisterViews { get; }
		public void AddRegisterViews(RegisterViewModel registerView);
		RegisterViewModel Delete(int Id);
		RegisterViewModel GetRegisterViews(int Id);

		public void EditRegisterViews(RegisterViewModel registerView);

		public bool Authentication(string u, string p);
		

	}
}
