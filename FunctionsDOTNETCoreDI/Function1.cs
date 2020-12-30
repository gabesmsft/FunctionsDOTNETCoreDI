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
        private readonly ILogger<Function1> _logger;

        private readonly IConfiguration _configuration;

        private readonly IMyDependency1 _myDependency1;

        private readonly IMyDependency2 _myDependency2;

        public Function1(ILogger<Function1> logger, IConfiguration configuration, IMyDependency1 myDependency1, IMyDependency2 myDependency2)
        {
            _logger = logger;

            _configuration = configuration;

            _myDependency1 = myDependency1;

            _myDependency2 = myDependency2;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req /*, ILogger log*/)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string fakeAppSetting = _configuration["FakeAppSetting"];

            _logger.LogInformation("FakeAppSettingValue: " + fakeAppSetting);

            //if the following prints "MyDependency1 successfully injected", we know MyDependency1 was sucessfully injected because this message was passed into the constructor during registration 
            _logger.LogInformation("MyDependency1.TestDependencyInjection() return value: " + _myDependency1.TestDependencyInjection());

            _myDependency2.DoSomeLogging();


           SomeClass someClass3 = new SomeClass();
            //the purpose of the following call is to demonstrate what is *not* a good practice for logging,
            //and why the approach demonstrated for _myDependency2 is typically better.
           // someClass3.DoSomeLogging(log);

            return new OkObjectResult("hello");
        }
    }
}
