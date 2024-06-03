using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataBase.Repositories;
using DataBase.Repositories.Abstraction;

namespace WebApp
{
    public class WebAppEntryPoint
    {
        public static void Main(string[] args)
        {
            var host = WebAppEntryPoint.CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Start>(); })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterType<ProductRepository>().As<IProductRepository>();
                });
    }
}
