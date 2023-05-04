using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace sporsalonutakipsistemi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllersWithViews();
			services.AddAuthorization(options =>
			{
				options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
				options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
			});
			services.AddAuthentication("MyScheme")
	.AddCookie("MyScheme", options =>
	{
		options.AccessDeniedPath = "/AccessDenied";
		options.LoginPath = "/Login";
		options.Events = new CookieAuthenticationEvents
		{
			OnRedirectToLogin = context =>
			{
				if (context.Request.Path.StartsWithSegments("/Admin") &&
					!context.Request.Path.StartsWithSegments("/Login"))
				{
					context.Response.Redirect("/Login");
				}
				else if (context.Request.Path.StartsWithSegments("/User") &&
						 !context.Request.Path.StartsWithSegments("/Login/UserLogin"))
				{
					context.Response.Redirect("/Login/UserLogin");
				}
				else
				{
					context.Response.Redirect(context.RedirectUri);
				}

				return Task.CompletedTask;
			}
		};
	});

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
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();



			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Default}/{action=Index}/{id?}");
			});


		}
	}
}
