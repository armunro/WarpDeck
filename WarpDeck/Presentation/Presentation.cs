using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace WarpDeck.Presentation
{
    public class Presentation
    {
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacChildLifetimeScopeServiceProviderFactory(Program.Container.BeginLifetimeScope("root-one")))
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<AspNetCoreStartup>());

        public static void StartAsync(string[] args) => CreateHostBuilder(args).Build().RunAsync();
    }
}