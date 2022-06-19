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
            LinearEquation a = new LinearEquation(1, 3);
            LinearEquation b = new LinearEquation(1, 2);

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
        public void LinearEquationTestAddition1()
        {
            LinearEquation a = new LinearEquation(1, 3);
            LinearEquation b = new LinearEquation(1, 2);
            LinearEquation r = a + b;
            Assert.IsTrue(r[0] == 2 && r[1] == 5);
        }
        [TestMethod]
        public void LinearEquationTestAddition2()
        {
            LinearEquation a = new LinearEquation(1, 0, 3);
            LinearEquation b = new LinearEquation(2, 2);
            LinearEquation r = a + b;
            Assert.IsTrue(r[0] == 3 && r[1] == 2 && r[2] == 3);
        }
        [TestMethod]
        public void LinearEquationTestDifference1()
        {
            LinearEquation a = new LinearEquation(1, 3);
            LinearEquation b = new LinearEquation(1, 2);
            LinearEquation r = a - b;
            Assert.IsTrue(r[0] == 0 && r[1] == 1);
        }
        [TestMethod]
        public void LinearEquationTestDifference2()
        {
            LinearEquation a = new LinearEquation(1, 0, 3);
            LinearEquation b = new LinearEquation(2, 2);
            LinearEquation r = a - b;
            Assert.IsTrue(r[0] == -1 && r[1] == -2 && r[2] == 3);
        }
        [TestMethod]
        public void LinearEquationTestBool()
        {
            LinearEquation a = new LinearEquation(0, 3);
            if(a) Assert.IsTrue(true);
            else Assert.IsTrue(false);
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
    }
}
