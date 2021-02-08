using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionsDOTNETCoreDI
{
    public class MyDependency4 : IMyDependency4
    {
        private string TestString;

        public MyDependency4()
        {
            TestString = "MyDependency4";
        }

        public String TestDependencyInjection4()
        {
            return TestString;
        }
    }
}
