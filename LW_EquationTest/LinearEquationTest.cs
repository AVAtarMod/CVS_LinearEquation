using Microsoft.VisualStudio.TestTools.UnitTesting;
using LW_Equation;
using System;

namespace LW_EquationTest
{
    [TestClass]
    public class LinearEquationTests
    {
        [TestMethod]
        public void LinearEquationTestEquals()
        {
            LinearEquation a = new LinearEquation(1, 2);
            LinearEquation b = new LinearEquation(1, 2);

            bool result = a == b;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LinearEquationTestEquals2()
        {
            LinearEquation a = new LinearEquation(1, 2);
            LinearEquation b = new LinearEquation(1, 3);

            bool result = a == b;

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void LinearEquationTestEqualsDiffSize()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            LinearEquation b = new LinearEquation(1, 2);

            bool result = a == b;

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void LinearEquationTestNotEquals()
        {
            LinearEquation a = new LinearEquation(1, 3);
            LinearEquation b = new LinearEquation(1, 2);

            bool result = a != b;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LinearEquationTestNotEqualsDiffSize()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            LinearEquation b = new LinearEquation(1, 2);

            bool result = a != b;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LinearEquationTestIndexer()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);

            bool result = a[1] == 2;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LinearEquationTestIndexer2()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);

            bool result = a[2] == 3;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LinearEquationTestIndexer3()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);

            bool result = a[0] == 1;

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
        [TestMethod]
        public void LinearEquationTestOpeartorEqPlusFloat()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            float b = 5.4F;

            LinearEquation result = a + b;

            Assert.AreEqual(new LinearEquation(1, 2, 8.4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqPlusFloat2()
        {
            LinearEquation a = new LinearEquation(1, 2);
            float b = 5.4F;

            LinearEquation result = a + b;

            Assert.AreEqual(new LinearEquation(1, 7.4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqPlusFloat3()
        {
            LinearEquation a = new LinearEquation(1, 2);
            float b = 1F;

            LinearEquation result = a + b;

            Assert.AreEqual(new LinearEquation(1, 3F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqPlusFloat4()
        {
            LinearEquation a = new LinearEquation(1, 2);
            float b = -1F;

            LinearEquation result = a + b;

            Assert.AreEqual(new LinearEquation(1, 1F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            float b = 5.4F;

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1, 2, -2.4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat2()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            float b = -5.4F;

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1, 2, 8.4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat3()
        {
            LinearEquation a = new LinearEquation(1, 2);
            float b = 5.4F;

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1, -3.4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat4()
        {
            LinearEquation a = new LinearEquation(1, 3);
            float b = -5.4F;

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1, 8.4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat5()
        {
            LinearEquation a = new LinearEquation(1, 3);
            float b = -1F;

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1, 4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat6()
        {
            LinearEquation a = new LinearEquation(1, 3);
            float b = 1F;

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1, 2F), result);
        }


        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusEq()
        {
            LinearEquation a = new LinearEquation(3, 4);
            LinearEquation b = new LinearEquation(1, 3);

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(2, 1), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqPlusEq()
        {
            LinearEquation a = new LinearEquation(1, 3);
            LinearEquation b = new LinearEquation(1, 3);

            LinearEquation result = a + b;

            Assert.AreEqual(new LinearEquation(2, 6), result);
        }
        [TestMethod]
        public void EqHasDesicion()
        {
            LinearEquation a = new LinearEquation(1, 5, 3);
            var res = a.IsDesided(1, 2);
            Assert.AreEqual(res, -4.0);
        }
        [TestMethod]
        public void GetEq()
        {
            var res = new LinearEquation(1, 5, 3).GetDesicion().Contains("1*(1) + 5*(2) + 3*(3) = 0");
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void MultOnNum()
        {
            var res = new LinearEquation(1, 5, 3);
            res.MultOnNum(3);
            Assert.AreEqual(res, new LinearEquation(3,15,9));
        }
        [TestMethod]
        public void GetRandNumbs()
        {
            var arr = new LinearEquation();
            Assert.AreEqual(arr.Size >= 1, true);
        }
        [TestMethod]
        public void MinusNumber()
        {
            var arr = new LinearEquation(1,3,5);
            Assert.AreEqual(-arr, new LinearEquation(-1, -3, -5));
        }
        [TestMethod]
        public void DoubleList()
        {
            var list = new LinearEquation(1, 2, 3).GetDoubleList();
            Assert.AreEqual(list.GetType(), typeof(List<double>));
        }
    }
}
