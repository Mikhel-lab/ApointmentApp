using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApointmentApp.Models
{

	[Table("Mobiledata")]
	public class MobileData
	{
		[Key]
		public int MobileId { get; set; }
		public string MobileName { get; set; }
		public string MobileManufactured { get; set; }
		public Nullable<decimal> MobilePrice { get; set; }
		[NotMapped]
		public SelectList MobileList { get; set; }
	}
}
