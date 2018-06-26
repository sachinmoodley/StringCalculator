using System;
using NUnit.Framework;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturnZero()
        {
            //Arrange 
            var input = string.Empty;
            var calculator = CreateCalculator();

            //Act
            var actual = calculator.Add(input);

            //Assert
            var expected = 0;
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_GivenSingleNumber_ShouldReturnThatNumber()
        {
            //Arrange 
            var input = "1";
            var expected = 1;
            var calculator = CreateCalculator();

            //Act
            var actual = calculator.Add(input);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_GivenMultipleNumbersWithCommaDelimiter_ShouldReturnSum()
        {
            //Arrange 
            var input = "1,2,3";
            var expected = 6;
            var calculator = CreateCalculator();

            //Act
            var actual = calculator.Add(input);

            //Assert
            Assert.AreEqual(actual,expected);
        }

        [Test]
        public void Add_HandleNewLinesInbetweenNumbers_ShouldReturnSum()
        {
            //Arrange
            var input = "1\n2,3";
            var expected = 6;
            var calculator = CreateCalculator();

            //Act
            var actual = calculator.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenDifferentDelimiters_ShouldSupportTheseDelimiters()
        {
            //Arrange 
            var input = "//;\n1;2";
            var expected = 3;
            var calculator = CreateCalculator();

            //Act 
            var actual = calculator.Add(input);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowExpectionAndThatNegativeNumber()
        {
            //Arrange
            var input = "-1";
            var expected = "Negatives not allowed :-1";
            var calculator = CreateCalculator();

            //Act 
            var actual = Assert.Throws<Exception>(() => calculator.Add(input));

            //Assert 
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_GivenMultipleNegativeNumbers_ShouldThrowExpectionAndDisplayNegativeNegativeNumbers( )
        {
            //Arrange
            var input = "-1,-2,-3";
            var expected = "Negatives not allowed :-1,-2,-3";
            var calculator = CreateCalculator();
          
            //Act 
            var actual = Assert.Throws<Exception>(() => calculator.Add(input));

            //Assert 
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_GivenMultipleNumbers_ShouldThrowExceptionAndDisplayOnlyTheNegativeNumbers()
        {
            //Arrange
            var input = "2,-1,-2,-3,5,3";
            var expected = "Negatives not allowed :-1,-2,-3";
            var calculator = CreateCalculator();

            //Act 
            var actual = Assert.Throws<Exception>(() => calculator.Add(input));

            //Assert 
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_GivenNumbersGreaterThan1000_ShouldIgnoreTheseNumbers()
        {
            //Arrange 
            var calculator = CreateCalculator();
            var input = "2,1001";
            var expected = 2;

            //Act
            var actual = calculator.Add(input);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Add_GivenAnyLenghtOfDelimiter1_ShouldReturnSum()
        {
            //Arrange
            var input = "//[***]\n1***2**3";
            var expected = 6;
            var calculator = CreateCalculator();

            //Act
            var actual = calculator.Add(input);

            //Assert
            Assert.AreEqual(expected,actual);
        }
        
        
        [Test]
        public void Add_GivenAnyLenghtOfDelimiter2_ShouldReturnSum()
        {
            //Arrange
            var input = "//[|||]\n1|||2||3";
            var expected = 6;
            var calculator = CreateCalculator();

            //Act
            var actual = calculator.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenAnyLenghtOfDelimiter3_ShouldReturnSum()
        {
            //Arrange
            var input = "//[---]\n1---2--3";
            var expected = 6;
            var calculator = CreateCalculator();

            //Act
            var actual = calculator.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateCalculator()
        {
            var calculator = new StringCalculator();
            return calculator;
        }
    }
}
