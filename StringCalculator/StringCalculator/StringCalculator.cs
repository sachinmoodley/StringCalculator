using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input == string.Empty) { return 0; }
           
            var delimiters = GetDelimiter();
            input = HandleCustomDelimiters(input);

            var splitNumber = SplitNumbersWithDelimiters(input, delimiters);
            var convertedNumber = ConvertStringToNumbers(splitNumber);
            var validNumbers = AddNumbersThatAreValid(convertedNumber);

            ContainsNegatives(convertedNumber);

            return validNumbers.Sum();
        }

        private static char[] GetDelimiter()
        {
            var delimiters = new[] { ',', '\n' };
            return delimiters;
        }
        private static string HandleCustomDelimiters(string input)
        {
            if (input.StartsWith("//"))
            {
                input = input.Substring(2);
                var customDelimiter = input[0];
                input = input.Replace(customDelimiter, ',');
            }

            return input;
        }
        private static string[] SplitNumbersWithDelimiters(string input, char[] delimiters)
        {
            var splitNumber = input.Split((delimiters), StringSplitOptions.RemoveEmptyEntries);
            return splitNumber;
        }
        private static IEnumerable<int> ConvertStringToNumbers(string[] splitNumber)
        {
            var convertedNumber = splitNumber.Select(x => Convert.ToInt32(x));
            return convertedNumber;
        }
        private static List<int> AddNumbersThatAreValid(IEnumerable<int> convertedNumber)
        {
            var numbersThatAreValid = convertedNumber.Where(x => x < 1000).ToList();
            return numbersThatAreValid;
        }
        private static void ContainsNegatives(IEnumerable<int> convertedNumber)
        {
            var negatives = convertedNumber.Where(x => x < 0);
            if (negatives.Any())
            {
                var negativeString = string.Join(",", negatives);
                throw new Exception($"Negatives not allowed :{negativeString}");
            }
        }
    }
}
