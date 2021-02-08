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
        private readonly IMyDependency1 _myDependency1;
        private readonly IMyDependency2 _myDependency2;
        public Function1(IMyDependency1 myDependency1, IMyDependency2 myDependency2)
        {
            _myDependency1 = myDependency1;
            _myDependency2 = myDependency2;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger _logger)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            _logger.LogInformation("MyDependency1.TestDependencyInjection2() return value: " + _myDependency1.TestDependencyInjection2());

            _logger.LogInformation("MyDependency2.TestDependencyInjection1() return value: " + _myDependency2.TestDependencyInjection2());

            return new OkObjectResult("hello");
        }
    }
}
