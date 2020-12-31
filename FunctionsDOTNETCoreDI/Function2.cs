using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionsDOTNETCoreDI
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //Using the ILogger that the Functions runtime automatically injects. This is fine for basic purposes, but doesn't give you granular control over logging per Function/ per class.
            log.LogInformation("C# HTTP trigger function processed a request.");

            SomeNonDIClass someNonDIClass = new SomeNonDIClass();
            
            //the purpose of the following call is to demonstrate what is *not* a good practice for logging,
            //and why the approach demonstrated for MyDependency2 is typically better. Passing a logger between class instances is not ideal.
            someNonDIClass.DoSomeLogging(log);

            return new OkObjectResult("hello");
        }
    }
}
