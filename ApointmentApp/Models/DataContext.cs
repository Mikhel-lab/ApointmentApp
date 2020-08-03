using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApointmentApp.Models;
using CodebitCollegeEFC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ApointmentApp.ViewModels;

namespace ApointmentApp.Models
{
	public class DataContext : IdentityDbContext
	{

		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
		public DbSet<Manager> ManagersTable { get; set; }
		public DbSet<SystemUsers> SystemUsersTable { get; set; }
		public DbSet<RegisterViewModel> RegistersViewTable { get; set; }



	}
}
