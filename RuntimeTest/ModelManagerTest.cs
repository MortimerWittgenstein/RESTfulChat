using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTfulChat.Runtime;

namespace RuntimeTest
{
    [TestClass]
    public class ModelManagerTest
    {
        public class Example
        {
            int a, b;

            public Example Test { get; set; }
            public Example(int b, int a)
            {
                this.a = a;
                this.b = b;
            }
        };

        [TestMethod]
        public void CheckDefaultCheck()
        {

            var ex = new Example(0, 0)
            {
                Test = new Example(12, 4)
            };

            var ex2 = new Example(0, 0)
            {
                Test = new Example(12, 13)
            };

            int test = 0;

            var obj = (object)test;


            if (!ModelManager.IsDefault(obj))
                throw new Exception();

            ModelManager.Update(ex, ex2);

        }



    }
}
