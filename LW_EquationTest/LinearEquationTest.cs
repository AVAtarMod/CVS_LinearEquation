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
        public void LinearEquationTestToList()
        {
            LinearEquation a = new LinearEquation(1F, 1.2F, 3.4F);
            List<double> result = new List<double>() { 1F, 1.2F, 3.4F };
            List<double> equation = a.ToList();
            bool ans =  (result[0] == equation[0]) &&
                        (result[1] == equation[1]) &&
                        (result[2] == equation[2]);
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
            LinearEquation a = new LinearEquation(3, 5);
            bool ans = a != null;
            Assert.IsTrue(ans);
        }

    }
}
