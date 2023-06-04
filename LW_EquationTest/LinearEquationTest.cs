using System;
using LW_Equation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LW_EquationTest
{
    [TestClass]
    public class LinearEquationTests
    {
        [TestMethod]
        public void LinearEquationTestEquals()
        {
            LinearEquation A = new LinearEquation(1, 2);
            LinearEquation B = new LinearEquation(1, 2);
            LinearEquation C = new LinearEquation(1, 3);

            bool resultA_B = A == B;
            bool resultA_C = A == C;
            bool resultC_B = C == B;

            Assert.AreEqual(true, resultA_B);
            Assert.AreEqual(false, resultA_C);
            Assert.AreEqual(false, resultC_B);
        }
        [TestMethod]
        public void LinearEquationTestEqualsDiffSize()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            LinearEquation b = new LinearEquation(1, 2);

            bool result = a == b;

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void LinearEquationTestNotEquals()
        {
            LinearEquation a = new LinearEquation(1, 3);
            LinearEquation b = new LinearEquation(1, 2);

            bool result = a != b;

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void LinearEquationTestNotEqualsDiffSize()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            LinearEquation b = new LinearEquation(1, 2);

            bool result = a != b;

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void LinearEquationTestIndexer()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);

            Assert.AreEqual(1, a[0]);
            Assert.AreEqual(2, a[1]);
            Assert.AreEqual(3, a[2]);
        }
        [TestMethod]
        public void LinearEquationTestIndexerException()
        {
            LinearEquation a = new LinearEquation(1, 2);

            Exception resultLeft = Assert.ThrowsException<ArgumentOutOfRangeException>(() => a[-1]);
            Exception resultRight = Assert.ThrowsException<ArgumentOutOfRangeException>(() => a[2]);

            Assert.IsInstanceOfType(resultLeft, typeof(ArgumentOutOfRangeException));
            Assert.IsInstanceOfType(resultRight, typeof(ArgumentOutOfRangeException));
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
        public void TestAdditionOperator()
        {
            LinearEquation equation1 = new LinearEquation(1, 2, 3);
            LinearEquation equation2 = new LinearEquation(4, 5, 6);
            LinearEquation expected = new LinearEquation(5, 7, 9);
            LinearEquation result = equation1 + equation2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSubtractionOperator()
        {
            LinearEquation equation1 = new LinearEquation(1, 2, 3);
            LinearEquation equation2 = new LinearEquation(4, 5, 6);
            LinearEquation expected = new LinearEquation(-3, -3, -3);
            LinearEquation result = equation1 - equation2;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestHasSolution()
        {
            LinearEquation equationWithSolution = new LinearEquation(2, 4);
            LinearEquation equationWithoutSolution = new LinearEquation(0, 4);

            bool result1 = equationWithSolution.HasSolution();
            bool result2 = equationWithoutSolution.HasSolution();

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }
        [TestMethod]
        public void TestSolveSingleUnknown()
        {
            LinearEquation equation = new LinearEquation(2, 4);
            float expected = -2f;
            float result = equation.Solve();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestSolveMultipleUnknowns()
        {
            LinearEquation equation = new LinearEquation(2, 4, 6);

            Assert.ThrowsException<InvalidOperationException>(() => equation.Solve());
        }
        [TestMethod]
        public void TestToString()
        {
            LinearEquation equation = new LinearEquation(2, 4, 6);
            string expected = "2x1 + 4x2 + 6 = 0";
            string result = equation.ToString();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestInitializeRandom()
        {
            LinearEquation equation = new LinearEquation(2, 4, 6);
            equation.InitializeRandom();
            Assert.AreNotEqual(2, equation[0]);
            Assert.AreNotEqual(4, equation[1]);
            Assert.AreNotEqual(6, equation[2]);
        }
        //[TestMethod]
        //public void TestInitializeWithSameValue()
        //{
        //    LinearEquation equation = new LinearEquation(2, 4, 6);
        //    equation.InitializeWithSameValue(10);

        //    Assert.Equals(10, equation[0]);
        //    Assert.Equals(10, equation[1]);
        //    Assert.Equals(10, equation[2]);
        //}
        //[TestMethod]
        //public void TestMultiplicationOperator()
        //{
        //    LinearEquation equation = new LinearEquation(2, 4, 6);
        //    float scalar = 3;
        //    LinearEquation expected = new LinearEquation(6, 12, 18);
        //    LinearEquation result = scalar * equation;

        //    Assert.Equals(expected, result);
        //}
    }
}
