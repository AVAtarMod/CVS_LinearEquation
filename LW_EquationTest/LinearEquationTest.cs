using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
            Assert.AreEqual(new LinearEquation(-3, 2, -2), result);
        }
        [TestMethod]
        public void LinearEquationTestHasSolution()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            Assert.IsTrue(a.HasSolution());
        }
        [TestMethod]
        public void LinearEquationTestHasSolution1()
        {
            LinearEquation a = new LinearEquation(new List<float>() { 2 });
            Assert.IsFalse(a.HasSolution());
        }
        [TestMethod]
        public void LinearEquationTestSolution()
        {
            LinearEquation a = new LinearEquation(1, 2);
            float res = a.Solution();
            Assert.AreEqual(-0.5F, res);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void LinearEquationTestSolution1()
        {
            LinearEquation a = new LinearEquation(new List<float>() { 1 });
            Assert.Equals(a.Solution(), new Exception());
        }
        [TestMethod]
        public void LinearEquationTestToString()
        {
            LinearEquation a = new LinearEquation(1, 2, 3, 4);
            string res = a.ToString();
            Assert.AreEqual("4*a + 3*b + 2*c + 1 = 0", res);
        }
        [TestMethod]
        public void LinearEquationTestInitRand()
        {
            LinearEquation a = new LinearEquation(1,1,1);
            LinearEquation b = new LinearEquation(1,1,1);
            a = a.SetRandom();
            b = b.SetRandom();
            Assert.AreNotEqual(a, b);
        }
        [TestMethod]
        public void LinearEquationTestInitSame()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            a = a.SetSame(8);
            Assert.AreEqual(8, a[2]);

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
            List<double> res = a.ToDouble();
            Assert.AreEqual(new List<double>() { 9, 8 }, res);
        }

    }
}
