namespace Calc_Tester
{
    [TestClass]
    public sealed class Equations
    {
        [TestMethod]
        public void Addition()
        {
            string expected = "2";
            string actual = Assessment.Calculator.BEDMAS("1+1");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Subtraction()
        {
            string expected = "0";
            string actual = Assessment.Calculator.BEDMAS("1-1");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Multiplication()
        {
            string expected = "4";
            string actual = Assessment.Calculator.BEDMAS("2*2");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Division()
        {
            string expected = "1";
            string actual = Assessment.Calculator.BEDMAS("2/2");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Exponents()
        {
            string expected = "8";
            string actual = Assessment.Calculator.BEDMAS("2^3");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Factorial()
        {
            string expected = "24";
            string actual = Assessment.Calculator.BEDMAS("4!");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Broken()
        {
            string expected = "Syntax Error";
            string actual = Assessment.Calculator.BEDMAS("1++1");
            Assert.AreEqual(expected, actual);
        }
    }
}
