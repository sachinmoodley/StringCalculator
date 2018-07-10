using System;
using NUnit.Framework;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("", 0)]
        [TestCase(null, 0)]
        public void Add_GivenNullOrEmptyString_ShouldReturnZero(string input, int expected)
        {
            //------Arrange-------
            var sut = CreateCalculator();

            //--------Act---------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", 1)]
        [TestCase("13", 13)]
        [TestCase("145", 145)]
        public void Add_GivenSingleNumber_ShouldReturnThatNumber(string input, int expected)
        {
            //------Arrange-------
            var sut = CreateCalculator();

            //--------Act---------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2,56,3,5,3,54,3", 127)]
        public void Add_GivenAnyAmountOfCommaDelimiterNumber_ShouldReturnSum(string input, int expected)
        {
            //------Arrange-------
            var sut = CreateCalculator();

            //--------Act---------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNewLineInBetweenNumbers_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "1\n2,3";
            var expected = 6;
            var sut = CreateCalculator();

            //--------Act---------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//@\n1@2", 3)]
        [TestCase("//*\n1*2", 3)]
        public void Add_GivenDifferentDelimiters_ShouldReturnSum(string input, int expected)
        {
            //------Arrange-------
            var sut = CreateCalculator();

            //--------Act---------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1", "Negatives not allowed :-1")]
        [TestCase("-1,-4,-2", "Negatives not allowed :-1,-4,-2")]
        [TestCase("-1,-5,-3,4,8", "Negatives not allowed :-1,-5,-3")]
        public void Add_GivenAnyAmountOfNegativeNumbers_ShouldThrowExceptionAndMessageOfOnlyNegatives(string input, string expected)
        {
            //------Arrange-------
            var sut = CreateCalculator();

            //--------Act---------
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //------Assert-------
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("2,1002", 2)]
        [TestCase("999,1000,1001", 999)]
        [TestCase("1,11,111,1111", 123)]
        public void Add_GivenNumberGreaterThan1000_ShouldIgnoreNumber(string input, int expected)
        {
            //------Arrange-------
            var sut = CreateCalculator();

            //--------Act---------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[|||]\n4|||5|||3", 12)]
        [TestCase("//[---]\n4---4---33", 41)]
        public void Add_GivenAnyLengthOfDelimiters_ShouldReturnSum(string input, int expected)
        {
            //------Arrange-------
            var sut = CreateCalculator();

            //--------Act--------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[|][!]\n4|32!4", 40)]
        [TestCase("//[=][-]\n7=34-23", 64)]
        public void Add_GivenMultipleDeifferentDeliiters_ShouldReturnSum(string input, int expected)
        {
            //------Arrange-------
            var sut = CreateCalculator();

            //--------Act--------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[****][##][==]\n34****2##54==43", 133)]
        public void Add_GivenMultipleDelimitersWithAnyLength_ShouldReturnSum(string input, int expected)
        {
            //------Arrange-------
            var sut = CreateCalculator();

            //--------Act--------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateCalculator()
        {
            return new StringCalculator();
        }
    }
}
