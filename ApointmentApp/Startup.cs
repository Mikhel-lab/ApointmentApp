using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApointmentApp.LoginRepo;
using ApointmentApp.ManagerRepo;
using ApointmentApp.Models;
using CodebitCollegeEFC.AccountRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace ApointmentApp
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		public static int Progress { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.Configure<CookiePolicyOptions>(options => { options.CheckConsentNeeded = context => true; options.MinimumSameSitePolicy = SameSiteMode.None; });
			services.AddDbContext<SchoolContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FastLearning")));
			services.AddMvc();
			services.AddControllersWithViews();
			services.AddDistributedMemoryCache();
			services.AddSession();
			services.AddTransient<IManager, ManagerRepository>();
			services.AddTransient<IRegisterAccount, RegisterAccountRepository>();
			services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DataContext>();
			services.AddTransient<IAccount, AccountRepository>();
			
				


			string conString = Configuration["ConnectionStrings:AppointmentManager"];
			services.AddDbContext<DataContext>(options => options.UseSqlServer(conString));


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseSession();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
