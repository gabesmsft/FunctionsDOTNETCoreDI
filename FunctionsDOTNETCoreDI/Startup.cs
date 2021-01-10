using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Options;
using System;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.AspNetCore.Hosting;

[assembly: FunctionsStartup(typeof(FunctionsDOTNETCoreDI.Startup))]

namespace FunctionsDOTNETCoreDI
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            FunctionsHostBuilderContext context = builder.GetContext();
            var serviceProvider = builder.Services.BuildServiceProvider();
            var defaultConfig = serviceProvider.GetRequiredService<IConfiguration>();
            var appDirectory = serviceProvider.GetRequiredService<IOptions<ExecutionContextOptions>>().Value.AppDirectory;
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(appDirectory)
                .AddJsonFile("appsettings1.json", false)
                .AddJsonFile($"appsettings1.{context.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            var customConfig = configBuilder.AddConfiguration(defaultConfig).Build();
        }
    }
}
