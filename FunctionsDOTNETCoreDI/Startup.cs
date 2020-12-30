using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;


[assembly: FunctionsStartup(typeof(FunctionsDOTNETCoreDI.Startup))]

namespace FunctionsDOTNETCoreDI
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            /*
            //don't use the following, since we dont want to override the Functions-runtime-provided logging

            builder.Services.AddLogging((loggingBuilder) =>
            {
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            });
            */

            //Registering MyDependency1 and MyDependency2 as services so that they can be dependency-injected into a client
            builder.Services.AddTransient<IMyDependency1, MyDependency1>(s => new MyDependency1("MyDependency1 successfully injected"));
            builder.Services.AddScoped<IMyDependency2, MyDependency2>();
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            FunctionsHostBuilderContext context = builder.GetContext();

            builder.ConfigurationBuilder
           .AddJsonFile(Path.Combine(context.ApplicationRootPath, "appsettings1.json"), optional: false, reloadOnChange: false)
           .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"appsettings1.{context.EnvironmentName}.json"), optional: true, reloadOnChange: false)
           .AddEnvironmentVariables();
        }
    }
}
