using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pharmacy_Management_System.Data;
using Pharmacy_Management_System.Models;
using Pharmacy_Management_System.Reposatory;

namespace Pharmacy_Management_System
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<PharamyContext>(Options=>Options.UseSqlServer(builder.Configuration.GetConnectionString("CS")));

   builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PharamyContext>();

			builder.Services.AddIdentity<User, IdentityRole>(Options => {
				Options.Password.RequiredLength = 6;
				Options.Password.RequireUppercase = false;
			}).AddEntityFrameworkStores<PharamyContext>();
			builder.Services.AddScoped<User, User>();
			builder.Services.AddScoped<IdentityRole,IdentityRole>();
			builder.Services.AddScoped<RolesReposatory, RolesReposatory>();
			builder.Services.AddScoped< IReposatory<IdentityRole> ,RolesReposatory>();
			builder.Services.AddScoped<IReposatory<Medicine>, MedicineReposatory>();
			builder.Services.AddScoped<IReposatory<Stock>, StockReposatory>();
			builder.Services.AddAuthentication().AddFacebook(
				Options =>
				{
					Options.ClientId = "587317400621913";
					Options.ClientSecret = "6e87cc174d4bfc19cd5e2e942f551458";
					
				}
				);
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=User}/{action=Login}/{id?}");

			app.Run();
		}
	}
}
