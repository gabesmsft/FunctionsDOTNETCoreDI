﻿using Microsoft.Extensions.Logging;

namespace FunctionsDOTNETCoreDI
{
    public class MyDependency2 : IMyDependency2
    {
        private readonly ILogger<MyDependency2> _logger;

        public MyDependency2(ILogger<MyDependency2> logger)
        {
            _logger = logger;
        }

        public void DoSomeLogging()
        {
           _logger.LogInformation("ILogger in action in MyDependency2 class");
        }

    }
}
