//  using System;
//  using System.Collections.Generic;
//  using System.Linq;
//  using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
//  using Microsoft.AspNet.Http;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Dnx.Runtime;
using EmptyApplication.Data;

namespace EmptyApplication
{
    public class Startup
    {
        private readonly IConfiguration _configuration;        

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            _configuration = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddEnvironmentVariables()
                .AddJsonFile("config.json")
                .Build();
        }
        
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = _configuration["Production:SqliteConnectionString"];
 
            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<DataEventRecordContext>(options => options.UseSqlite(connection));
 
            services.AddMvc();
            services.AddScoped<IDataEventRecordResporitory, DataEventRecordResporitory>();            
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseErrorPage();
            app.UseRuntimeInfoPage();

            app.UseMvcWithDefaultRoute();

            //  app.UseMvc(routes => routes.MapRoute("default",
            //      "{controller=Home}/{action=Index}"));

            //  app.Run(async (context) =>
            //  {
            //      await context.Response.WriteAsync("Hello World Updated Again!");
            //  });
        }
    }
}
