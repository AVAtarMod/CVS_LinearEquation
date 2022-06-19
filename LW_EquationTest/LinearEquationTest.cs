using Microsoft.VisualStudio.TestTools.UnitTesting;
using LW_Equation;
using System;
using System.Collections.Generic;

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
        public void LinearEquationTestOperatorEqPlusEq()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            LinearEquation b = new LinearEquation(4, 5);
            LinearEquation result = a + b;
            Assert.AreEqual(new LinearEquation(5, 2, 8), result);
        }
        [TestMethod]
        public void LinearEquationTestOperatorEqMinusEq()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            LinearEquation b = new LinearEquation(4, 5);
            LinearEquation result = a - b;
            Assert.AreEqual(new LinearEquation(-2, 2, -3), result);
        }
        [TestMethod]
        public void LinearEquationTestOperatorTrue()
        {
            LinearEquation a = new LinearEquation(0, 0, 0, 1);
            bool ans = false;
            if (a)
                ans = true;
            else
                ans = false;

            Assert.IsFalse(ans);
        }
        
        [TestMethod]
        public void LinearEquationTestSolve()
        {
            LinearEquation a = new LinearEquation(2, 0, 5);

            float ans = 0;
            a.Solve(out ans);
            float trueans = (0F - 5F) / 2F;
            bool t = ans.CompareTo(trueans) == 0;
            Assert.IsTrue(t);
        }
        
        [TestMethod]
        public void LinearEquationTestToString()
        {
            LinearEquation a = new LinearEquation(1, 2, 3, 4, 5);
            bool ans = a.ToString() == "1,2,3,4,5";
            Assert.IsTrue(ans);
        }
        [TestMethod]
        public void LinearEquationTestInitSame()
        {
            LinearEquation a = new LinearEquation(true, 3, 5);
            LinearEquation res = new LinearEquation(5, 5, 5);
            bool ans = (a[0] == res[0]) &&
                       (a[1] == res[1]) &&
                       (a[2] == res[2]);
            Assert.IsTrue(ans);
        }

        [TestMethod]
        public void LinearEquationTestInitRandom()
        {
            LinearEquation a = new LinearEquation(true, 3);
            bool ans = a != null;
            Assert.IsTrue(ans);
        }
        [TestMethod]
        public void LinearEquationTestMultiplyByNumber1()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            LinearEquation result = a.MultiplyByNumber(2);
            LinearEquation correct = new LinearEquation(2, 4, 6);
            bool b = result.Equals(correct);

            Assert.IsTrue(b);
        }

        [TestMethod]
        public void LinearEquationTestOperatirEqMultFloat()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            a = a * 2F;
            Assert.AreEqual(4F, a[1]);
        }
        
        [TestMethod]
        public void LinearEquationTestOperatorMinus()
        {
            LinearEquation a = new LinearEquation(1, 0, 3);
            a = -a;
            Assert.AreEqual(-1, a[0]);
        }
        [TestMethod]
        public void LinearEquationTestOperatorMinus1()
        {
            LinearEquation a = new LinearEquation(1, 0, 3);
            a = -a;
            Assert.AreEqual(0, a[1]);
        }
        [TestMethod]
        public void LinearEquationTestToDouble()
        {
            LinearEquation a = new LinearEquation(9, 8);

            Assert.AreEqual(typeof(List<double>), a.ToDouble().GetType());
        }
        [TestMethod]
        public void LinearEquationTestToDouble1()
        {
            LinearEquation a = new LinearEquation(9, 8);
            List<double> res = a.ToDouble();
            Assert.AreEqual(new List<double>() { 9, 8 }, res);
            Assert.AreEqual(9, res[0]);
        }
    }
}
