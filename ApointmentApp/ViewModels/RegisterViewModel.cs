﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApointmentApp.ViewModels
{
	public class RegisterViewModel
	{
		public int ID { get; set; }

		[Required]
		public string Username { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public string Status { get; set; }
		public string Role { get; set; }
	}
}
