using BusinessLogic;
using BusinessLogic.Interface;
using BusinessLogic.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WARDxAPI.Interface;
using WARDxAPI.Model;

namespace WARDxAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "WARDx.Session";
            });

            services.AddIdentity<WARDxUser, WARDxRole>()
            .AddDefaultTokenProviders();
           
            // business logic implementations of application user and role
            services.AddTransient<IUserStore<WARDxUser>, WARDxUserStore>();
            services.AddTransient<IRoleStore<WARDxRole>, WARDxRoleStore>();
            services.AddTransient<IPasswordHasher<WARDxUser>, WARDxUserStore>();
            services.AddTransient<IWARDxPasswordHasher, WARDxPasswordHasher>();

            // business logic implementation of the class 'IBusinessLogic'
            services.AddTransient<IBusinessLogic, Logic>();

            // business logic implementation of the helper class 'DataProvider'
            services.AddTransient<IDataProvider, DataProvider>();
            
            // business logic implementation of the helper class 'IDropdownProcessor'
            services.AddTransient<IDropdownProcessor, Logic>();

            // business logic implementation of the helper class 'IPatientProvider'
            services.AddTransient<IPatientProcessor, Logic>();

            // business logic implementation of the helper class 'IAdmissionProvider'
            services.AddTransient<IAdmissionProcessor, Logic>();

            // business logic implementation of the helper class 'IPatientMoveProvider'
            services.AddTransient<IMoveProcessor, Logic>();

            // business logic implementation of the helper class 'IEmailSender'
            services.AddTransient<IEmailSender, Logic>();

            // business logic implementation of the helper class 'IStaffProcessor'
            services.AddTransient<IStaffProcessor, Logic>();

            //services.AddTransient<ISchedulingProcessor, Logic>();

            //business logic implementation of the helper class 'ITreatmentProcessor'
            services.AddTransient<ITreatmentProcessor, Logic > ();
        
            services.AddTransient<ISchedulingProcessor, Logic>();
        
            //  WARDx application security settings
            services.ConfigureApplicationCookie(options =>
            {
                // store a cookie on the local machine
                options.Cookie.HttpOnly = true;
                // path to the login view
                options.LoginPath = "/Account/Login";
                // path to the logout view
                options.LogoutPath = "/Account/Logout";
                // name of the authentication cookie
                options.Cookie.Name = "WARDx.Security.Identity";
                // the time before the cookie expires
                options.Cookie.MaxAge = TimeSpan.FromMinutes(60);
                // issue a new cookie if the user is still active
                options.SlidingExpiration = true;
            });
          

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if we are in development 'Visual Studio'
            //if (env.IsDevelopment())
            //{
              //app.UseDeveloperExceptionPage();
            //}
            // if we are running on the server
            //else
            //{
              //app.UseExceptionHandler("/Home/Error");
            //}

            app.UseHttpsRedirection();
            // loads files in the 'wwwroot' folder
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
