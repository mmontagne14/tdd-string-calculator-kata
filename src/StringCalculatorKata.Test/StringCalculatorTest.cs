using System;
using System.Security.Cryptography;
using NUnit.Framework;
using StringCalculatorKata;

namespace StringCalculatorKata.Test
{
    public class StringCalculatorTest
    {
        [Test]
        public void Add_StringEmpty_ReturnsZero()
        {
            Assert.AreEqual(0, StringCalculator.Add(""));
        }

        [TestCase(5, "5")]
        [TestCase(1, "1")]
        public void Add_OneNumber_ReturnsSameNumber(int expected, string numbers)
        {
            Assert.AreEqual(expected, StringCalculator.Add(numbers));
        }

        [TestCase(3, "1,2")]
        [TestCase(5, "3,2")]
        public void Add_TwoNumbers_ReturnsSumThemUp(int expected, string numbers)
        {
            Assert.AreEqual(expected, StringCalculator.Add(numbers));
        }

        [TestCase(10, "3,5,2")]
        [TestCase(20, "3,5,2,10")]
        public void Add_UnknownAmountOfNumbers(int expected, string numbers)
        {
            Assert.AreEqual(expected, StringCalculator.Add(numbers));
        }
        [TestCase(6, "1\n2, 3")]
        [TestCase(10, "1\n2,3\n4")]
        public void Add_NewLinesBetweenNumbers(int expected, string numbers)
        {
            Assert.AreEqual(expected, StringCalculator.Add(numbers));
        }

        [Test]
        public void Add_SupportDifferentDelimiters()
        {
            Assert.AreEqual(3, StringCalculator.Add("//;\n1;2"));
        }
    }
}
