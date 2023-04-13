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
        public void LinearEquationTestOpeartorEqPlusEquation()
        {
            LinearEquation a = new LinearEquation(1, 3);
            LinearEquation b = new LinearEquation(1, 3);
            

            LinearEquation result = a + b;

            Assert.AreEqual(new LinearEquation(2, 6), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqPlusEquation2()
        {
            LinearEquation a = new LinearEquation(1, 3,5,5.6f);
            LinearEquation b = new LinearEquation(1, 3,5,5.6F);
            

            LinearEquation result = a + b;

            Assert.AreEqual(new LinearEquation(2, 6,10,11.2f), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqPlusEquation3()
        {
            LinearEquation a = new LinearEquation(1, 3,-2);
            LinearEquation b = new LinearEquation(1, 3,4);
            

            LinearEquation result = a + b;

            Assert.AreEqual(new LinearEquation(2, 6,2), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusEquation()
        {
            LinearEquation a = new LinearEquation(1, 3);
            LinearEquation b = new LinearEquation(2,2);
            

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(-1, 1), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusEquation2()
        {
            LinearEquation a = new LinearEquation(1, 2);
            LinearEquation b = new LinearEquation(1,2);
            

            LinearEquation result = a - b;

            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusEquation3()
        {
            LinearEquation a = new LinearEquation(2, 2,3);
            LinearEquation b = new LinearEquation(1,2);
            

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1,0,3), result);
        }
        //[TestMethod]
        //public void LinearEquationTestOpeartorEqMinusEquation4()
        //{
        //    LinearEquation a = new LinearEquation(1, 2);
        //    LinearEquation b = new LinearEquation(2,2,3);


        //    LinearEquation result = a - b;

        //    Assert.AreEqual(new LinearEquation(1,0,3), result);
        //}
        [TestMethod]
        public void LinearEquationTestOpeartorHaveSolution()
        {
            LinearEquation a = new LinearEquation(2, 2, 3);
            LinearEquation b = new LinearEquation(0);
            LinearEquation c = new LinearEquation(1);



            Assert.AreEqual(true, a.haveSolution());
            Assert.AreEqual(true, b.haveSolution());
            Assert.AreEqual(false, c.haveSolution());
        }
    }
}
