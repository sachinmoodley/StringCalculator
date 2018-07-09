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

        [Test]
        public void Add_GivenSingleNumber_ShouldReturnThatNumber()
        {
            //------Arrange-------
            var input = "1";
            var expected = 1;
            var sut = CreateCalculator();

            //--------Act---------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_Given2NumbersWithACommaDelimiter_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "1,2";
            var expected = 3;
            var sut = CreateCalculator();

            //--------Act---------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenUnknownAmountOfNumbers_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "1,3,5,6,4,6,4";
            var expected = 29;
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

        [Test]
        public void Add_GivenDifferentDelimiters_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "//;\n1;2";
            var expected = 3;
            var sut = CreateCalculator();

            //--------Act---------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowException()
        {
            //------Arrange-------
            var input = "-1";
            var expected = "Negatives not allowed :-1";
            var sut = CreateCalculator();

            //--------Act---------
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //------Assert-------
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_GivenMultipleNegativeNumber_ShouldThrowException()
        {
            //------Arrange-------
            var input = "-1,-5,-3,4,8";
            var expected = "Negatives not allowed :-1,-5,-3";
            var sut = CreateCalculator();

            //--------Act---------
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //------Assert-------
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_GivenNumberGreaterThan1000_ShouldIgnoreNumber()
        {
            //------Arrange-------
            var input = "2,1002";
            var expected = 2;
            var sut = CreateCalculator();

            //--------Act---------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenAnyLengthOfDelimiters_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "//[***]\n1***2***3";
            var expected = 6;
            var sut = CreateCalculator();

            //--------Act--------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenMultipleDeifferentDeliiters_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "//[*][%]\n1*2%3";
            var expected = 6;
            var sut = CreateCalculator();

            //--------Act--------
            var actual = sut.Add(input);

            //------Assert-------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenMultipleDelimitersWithAnyLenght_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "//[*][%]\n1*2%3";
            var expected = 6;
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
