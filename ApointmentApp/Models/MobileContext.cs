using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ApointmentApp.Models
{
	public class MobileContext
	{
		SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AppointmentManager"].ToString());
		public IEnumerable<MobileData> GetMobileDatas()
		{
			
			string result = "SELECT [MobileId], [MobileName] FROM [MobileDB].[dbo].[Mobiledata]";
			return View(result);
		}

		private IEnumerable<MobileData> View(string result)
		{
			throw new NotImplementedException();
		}
	}
}
