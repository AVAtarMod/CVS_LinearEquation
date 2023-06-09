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
        public void LinearEquationTestOpeartorSum()
        {
            LinearEquation a = new LinearEquation(4, 2, 5);
            LinearEquation b = new LinearEquation(1, -7, -3);
            LinearEquation c = a + b;

            Assert.AreEqual(5, c[0]);
            Assert.AreEqual(-5, c[1]);
            Assert.AreEqual(2, c[2]);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorSubtraction()
        {
            LinearEquation a = new LinearEquation(4, 2, 5);
            LinearEquation b = new LinearEquation(1, -7, -3);
            LinearEquation c = a - b;

            Assert.AreEqual(3, c[0]);
            Assert.AreEqual(9, c[1]);
            Assert.AreEqual(8, c[2]);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorBool()
        {
            LinearEquation a = new LinearEquation(0, 0, 4);
            LinearEquation b = new LinearEquation(1);
            LinearEquation c = new LinearEquation(1, 4, 3);

            Assert.AreEqual(false, a);
            Assert.AreEqual(false, b);
            Assert.AreEqual(true, c);
        }
        [TestMethod]
        public void LinearEquationTestGetRezult()
        {
            LinearEquation a = new LinearEquation(5, 7);
            //5x+7=0
            //x=-7/5
            float? rez = a.GetRoot(a);
            Assert.AreEqual(rez, (float)-1.4);
        }
        [TestMethod]
        public void LinearEquationTestToString()
        {
            LinearEquation a = new LinearEquation(7, -1, 0, 3544, -3, 17, 22);
            LinearEquation b = new LinearEquation(5, 0, 1, -1, -3, 1, 0);
            string LinEq = a.ToString();
            Assert.AreEqual(LinEq, "7x-x+3544x-3x+17x+22=0");
            LinEq = b.ToString();
            Assert.AreEqual(LinEq, "5x-x-3x+x=0");
        }
        [TestMethod]
        public void LinearEquationTestAddRandomNumberInLinearEq()
        {
            LinearEquation a = LinearEquation.RandomLinearEq(5);
            LinearEquation b = LinearEquation.RandomLinearEq(5);
            LinearEquation c = LinearEquation.RandomLinearEq(4);
            LinearEquation d = LinearEquation.RandomLinearEq(3);
            Assert.AreNotEqual(a.ToString(), b.ToString());
            Assert.AreNotEqual(c.ToString(), d.ToString());
            Assert.AreNotEqual(a.ToString(), c.ToString());
        }
    }
}
