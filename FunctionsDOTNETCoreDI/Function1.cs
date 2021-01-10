using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;


namespace FunctionsDOTNETCoreDI
{
    public class Function1
    {
        private readonly IConfiguration _configuration;
        public Function1( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string fakeAppSetting = _configuration["FakeAppSetting"];
            log.LogInformation("FakeAppSettingValue: " + fakeAppSetting);
            return new OkObjectResult("hello");
        }
    }
}
