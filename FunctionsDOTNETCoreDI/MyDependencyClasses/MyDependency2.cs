using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionsDOTNETCoreDI
{
    public class MyDependency2 : IMyDependency2
    {
        private string TestString;

        public MyDependency2()
        {
            TestString = "MyDependency2";
        }

        public String TestDependencyInjection2()
        {
            return TestString;
        }
    }
}
