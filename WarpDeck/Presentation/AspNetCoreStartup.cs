using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace WarpDeck.Presentation
{
    public class AspNetCoreStartup
    {
        private IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        public AspNetCoreStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages()
                .WithRazorPagesRoot(Defaults.RazorPagesRoot)
                .AddJsonOptions(
                    options => options.JsonSerializerOptions.IgnoreNullValues = true
                );
        }
        
        // Here's the change for child lifetime scope usage! Register your "root"
        // child lifetime scope things with the adapter.
        public void ConfigureContainer(AutofacChildLifetimeScopeConfigurationAdapter config)
        {
           
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "",
                FileProvider =
                    new PhysicalFileProvider(Path.Combine(Environment.CurrentDirectory, Defaults.PresentationDirectory))
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}