using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions;
using System.IO;

[assembly: FunctionsStartup(typeof(FunctionsDOTNETCoreDI.Startup))]

namespace FunctionsDOTNETCoreDI
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IMyDependency1, MyDependency1>();
            builder.Services.AddSingleton<IMyDependency2, MyDependency2>();
            builder.Services.AddSingleton<IMyDependency3, MyDependency3>();
            builder.Services.AddTransient<IMyDependency4, MyDependency4>();
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            FunctionsHostBuilderContext context = builder.GetContext();

            builder.ConfigurationBuilder
           .AddJsonFile(Path.Combine(context.ApplicationRootPath, "appsettings1.json"), optional: true, reloadOnChange: false)
           .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"appsettings1.{context.EnvironmentName}.json"), optional: true, reloadOnChange: false)
           .AddEnvironmentVariables();
        }
    }
}
