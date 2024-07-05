using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using StringCalculatorKata;

namespace StringCalculatorKata.Test
{
    public class StringCalculatorTest
    {
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            Assert.AreEqual(0, StringCalculator.Add(""));
        }

        [TestCase("5", 5)]
        [TestCase("7", 7)]
        public void Add_SingleNumber_ReturnsThatNumber(string numbers, int expected)
        {
            Assert.AreEqual(expected, StringCalculator.Add(numbers));
        }

        [TestCase("2,3", 5)]
        [TestCase("3,5", 8)]
        public void Add_TwoNumbers_ReturnSumThemUp(string numbers, int expected)
        {
            Assert.AreEqual(expected, StringCalculator.Add(numbers));
        }

        [TestCase("2,3,3", 8)]
        [TestCase("10,25,3", 38)]
        [TestCase("10,25,3,1,1", 40)]
        public void Add_MultipleNumbers_ReturnsSumThemUp(string numbers, int expected)
        {
            Assert.AreEqual(expected, StringCalculator.Add(numbers));
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("2\n4,8", 14)]
        [TestCase("2\n4,8\n10", 24)]
        public void Add_MultipleNumbers_NewLineAsDelimiter(string numbers, int expected)
        {
            Assert.AreEqual(expected, StringCalculator.Add(numbers));
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//.\n5.3", 8)]
        public void Add_MultipleNumbers_WithDelimiterSetting(string numbers, int expected)
        {
            Assert.AreEqual(expected, StringCalculator.Add(numbers));
        }

        [TestCase("-1", -1)]
        [TestCase("-15", -15)]
        [TestCase("2\n4,-8\n10", -8)]
        public void Add_MultipleNumbers_OneNegativeNumberRestriction(string numbers, int expected)
        {
            var ex = Assert.Throws<ArgumentException>(() => { StringCalculator.Add(numbers); });
            StringAssert.Contains(String.Format("negatives not allowed : {0}", expected.ToString()), ex.Message.ToString());
        }

        [TestCase("2\n4,-7\n-10", "-7 -10")]
        [TestCase("-2\n-4,-7\n-10", "-2 -4 -7 -10")]
        public void Add_MultipleNumbers_MultipleNegativeNumbersRestriction(string numbers, string expected)
        {
            var ex = Assert.Throws<ArgumentException>(() => { StringCalculator.Add(numbers); });
            StringAssert.Contains(String.Format("negatives not allowed : {0}", expected), ex.Message.ToString());
        }
    }
}
