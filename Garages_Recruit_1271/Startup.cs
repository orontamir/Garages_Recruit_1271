using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garages_Recruit_1271.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Garages_Recruit_1271
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>
               (options => options.UseSqlServer(_config.GetConnectionString("GaragesRecruit1271Connection")));

            services.Configure<DataProtectionTokenProviderOptions>(o =>
                       o.TokenLifespan = TimeSpan.FromHours(5));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 0;
                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
            services.AddMvc().AddXmlSerializerFormatters(); ;
           // services.AddSingleton<IUserRepository, MockUserRepository>();
            services.AddScoped<IUserRepository, SQLUserRepository>();
           
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
              
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
           // FileServerOptions fileServerOption = new FileServerOptions();
           // fileServerOption.DefaultFilesOptions.DefaultFileNames.Clear();
           // fileServerOption.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
           // app.UseFileServer(fileServerOption);
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");});
            //app.UseMvcWithDefaultRoute();
           // app.UseFileServer();
            //app.Run(async (context) =>
            //{          
            //    await context.Response.WriteAsync("Hello Word");
            //});
        }
    }
}
