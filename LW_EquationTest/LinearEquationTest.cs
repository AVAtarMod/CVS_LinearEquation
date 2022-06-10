using Microsoft.VisualStudio.TestTools.UnitTesting;
using LW_Equation;
using System;

namespace LW_EquationTest
{
    [TestClass]
    public class LinearEquationTests
    {
        [TestMethod]
        public void CorrectLength()
        {
            var linear = new LinearEquation(1, 2, 3, 4);
            Assert.AreEqual(4, linear.Length);
        }
        [TestMethod]
        public void Correctplus()
        {
            var linear1 = new LinearEquation(1, 2, 3, 4);
            var linear2 = new LinearEquation(1, 2, 3, 4, 5, 6);
            var lineartrue = new LinearEquation(1, 2, 4, 6, 8, 10);
            Assert.AreEqual((linear1 + linear2).ToString(), lineartrue.ToString());
        }
        [TestMethod]
        public void CorrectCompare()
        {
            var linear1 = new LinearEquation(1, 2, 3, 4);
            var linear2 = new LinearEquation(1, 2, 3, 4);
            Assert.AreEqual(linear2 == linear1, true);
        }
        [TestMethod]
        public void Correctminus()
        {
            var linear1 = new LinearEquation(1, 2, 3, 4, 5, 6);
            var linear2 = new LinearEquation(1, 2, 3, 4);
            var linear3 = new LinearEquation(1, 2, 2, 2, 4);
            var lineartrue1 = new LinearEquation(1, 2, 2, 2, 2, 2);
            var lineartrue2 = new LinearEquation(-1, -1, 0, 1, 0);
            Assert.AreEqual((linear1 - linear2).ToString(), lineartrue1.ToString());
            Assert.AreEqual((linear2 - linear3).ToString(), lineartrue2.ToString());
        }
        [TestMethod]
        public void Falsetest()
        {
            var linear = new LinearEquation(0, 0, 3);
            bool l = true;
            if (linear)
                l = false;
            Assert.AreEqual(false, l);
        }
        [TestMethod]
        public void Str()
        {
            var linear1 = new LinearEquation(1, 2, 3, 4);
            //string str = "1 2 3 4 ";
            Assert.AreEqual(linear1.ToString(), "1234");
        }
        [TestMethod]
        public void Correctmuti()
        {
            var linear1 = new LinearEquation(1, 2, 3, 4);
            var linear3 = new LinearEquation(1, 2, 3, 4);
            double r = 2;
            var linear2 = new LinearEquation(2, 4, 6, 8);
            Assert.AreEqual((linear1 * r).ToString(), linear2.ToString());
            Assert.AreEqual((r * linear3).ToString(), linear2.ToString());
        }
        [TestMethod]
        public void LinearEquationTestIndexer3()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);

            bool result = a[a.Length - 1] == 1;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LinearEquationTestIndexerException()
        {
            LinearEquation a = new LinearEquation(1, 2);

            Exception result = Assert.ThrowsException<ArgumentOutOfRangeException>(() => a[-1]);

            Assert.IsInstanceOfType(result, typeof(ArgumentOutOfRangeException));

        }
        [TestMethod]
        public void LinearEquationTestIndexerException2()
        {
            LinearEquation a = new LinearEquation(1, 2);

            Exception result = Assert.ThrowsException<ArgumentOutOfRangeException>(() => a[2]);

            Assert.IsInstanceOfType(result, typeof(ArgumentOutOfRangeException));
        }
    }
}
