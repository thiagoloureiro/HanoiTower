using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EI.Hanoi.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Assert.IsTrue(false);
        }
    }

    public class x
    {
        public int AddTwoPostiveNumber(int a, int b)
        {
            if (a > 0 || b > 0)
            {
                return -1;
            }

            return a + b;
        }
    }
}
