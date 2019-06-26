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
            // test: allow new lines and commas to separate
            int expected = 6;
            int test = Program.Add("1" + '\n' + ",2,3");
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void Test6()
        {
            // test: allow new delimeters
            int expected = 3;
            int test = Program.Add("//;" + '\n' + "1;2");
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void Test7()
        {
            // test: exception on a negative
            try
            {
                int test = Program.Add("-5");
                Assert.Fail();
            }
            catch(Exception ex)
            {
                if (ex.Message != "negatives not allowed: -5")
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void Test8()
        {
            // test: exception on a negatives
            try
            {
                int test = Program.Add("-5,-14,3,1,-3");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                if (ex.Message != "negatives not allowed: -5,-14,-3")
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void Test9()
        {
            // test: ignore numbers greater than 1000
            int expected = 1032;
            int test = Program.Add("2,4,8,9,1001,5,1000,4");
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void Test10()
        {
            // test: any length delimeter
            int expected = 6;
            int test = Program.Add("//[***]" + '\n' + "1***2***3");
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void Test11()
        {
            // test: multiple delimeters
            int expected = 6;
            int test = Program.Add("//[*][%]" + '\n' + "1*2%3");
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void Test12()
        {
            // test: multiple delimeters of varying lengths
            int expected = 1022;
            int test = Program.Add("//[;][***][%&]" + '\n' + "1,2;3" + '\n' + "4,5,1000, 1001%&5***2");
            Assert.AreEqual(expected, test);
        }

    }
}
