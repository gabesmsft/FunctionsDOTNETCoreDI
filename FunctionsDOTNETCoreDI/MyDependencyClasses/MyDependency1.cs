using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionsDOTNETCoreDI
{
    public class MyDependency1 : IMyDependency1
    {
        private string TestString;
        private readonly IMyDependency2 _myDependency2;

        public MyDependency1(IMyDependency2 myDependency2)
        {
            TestString = "MyDependency1";
            _myDependency2 = myDependency2;
        }

        public String TestDependencyInjection1()
        {
            return TestString;
        }
        public String TestDependencyInjection2()
        {
            return _myDependency2.TestDependencyInjection2();
        }
    }
}
