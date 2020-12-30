using Microsoft.Extensions.Logging;

namespace FunctionsDOTNETCoreDI
{
    public class SomeClass
    {

        public void DoSomeLogging(ILogger log)
        {
            log.LogInformation("SomeClass logging, via ILogger passed from calling class");
        }

    }
}
