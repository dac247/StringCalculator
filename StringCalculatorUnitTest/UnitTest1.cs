using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculatorUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            // test: empty string
            int expected = 0;
            int test = Program.Add("");
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void Test2()
        {
            // test: single number
            int expected = 15;
            int test = Program.Add("15");
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void Test3()
        {
            // test: two numbers
            int expected = 29;
            int test = Program.Add("15,14");
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void Test4()
        {
            // test: unknown number of numbers
            int expected = 32;
            int test = Program.Add("2,4,8,9,5,4");
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void Test5()
        {
            // test: unknown number of numbers
            int expected = 12;
            int test = Program.Add("6,2,4");
            Assert.AreEqual(expected, test);
        }










    }
}
