using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionsDOTNETCoreDI
{
    public class MyDependency3 : IMyDependency3
    {
        private string TestString;
        private readonly IMyDependency4 _myDependency4;

        public MyDependency3(IMyDependency4 myDependency4)
        {
            TestString = "MyDependency3";
            _myDependency4 = myDependency4;
        }

        public String TestDependencyInjection3()
        {
            return TestString;
        }
        public String TestDependencyInjection4()
        {
            return _myDependency4.TestDependencyInjection4();
        }
    }
}
