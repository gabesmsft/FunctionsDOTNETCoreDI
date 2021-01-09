using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Functions.Extensions;

[assembly: FunctionsStartup(typeof(FunctionsDOTNETCoreDI.Startup))]

namespace FunctionsDOTNETCoreDI
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddApplicationInsightsTelemetry()
                .AddLogging((loggingBuilder) =>
            {
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            });
        }
    }
}
