using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (EmptyString(input)) return 0;

            if (StartsWithDoubleSlashes(input))
            {
                if (input.Contains("["))
                {
                    input = GetMultipleDelimiter(input);
                }
                input = GetUnknowDelimiter(input);
            }
            var convertedNumber = AddConvertedNumbersToList(input);

            ThrowsExceptionIfContainsNegatives(convertedNumber);

            return convertedNumber.Sum();
        }

        private static void ThrowsExceptionIfContainsNegatives(IEnumerable<int> convertedNumber)
        {
            var negativeNumbers = GetNegativeNumbers(convertedNumber);
            if (negativeNumbers.Any())
            {
                var negativeString = string.Join(",", negativeNumbers);
                throw new Exception($"Negatives not allowed :{negativeString}");
            }
        }

        private static IEnumerable<int> GetNegativeNumbers(IEnumerable<int> convertedNumber)
        {
            return convertedNumber.Where(x => x < 0);
        }

        private static bool StartsWithDoubleSlashes(string input)
        {
            return input.StartsWith("//");
        }

        private static string GetMultipleDelimiter(string input)
        {
            var startText = "[";
            //var start = input.LastIndexOf(startText) + startText.Length;
            var starting = input.IndexOf("[");
            var end = input.IndexOf("]");
            var slashes = input.IndexOf("//");
            //var lenght = end - start;
            input = input.Remove(starting, end);
            input = input.Remove(slashes);
            //var multipleDelimiter = input.Substring(start, lenght);
            input = input.Replace('*', ',');
            return input;
        }

        private static string GetUnknowDelimiter(string input)
        {
            input = input.Substring(2);
            var split = input.Split('\n');
            var getNewDelim = Convert.ToChar(split[0]);
            input = input.Replace(getNewDelim, ',');

            return input;
        }

        private static List<int> AddConvertedNumbersToList(string input)
        {
            return ValidNumbers(input).ToList();
        }

        private static IEnumerable<int> ValidNumbers(string input)
        {
            return ConvertNumber(input).Where(x => x < 1000);
        }

        private static IEnumerable<int> ConvertNumber(string input)
        {
            return SeperateNumbers(input).Select(int.Parse);
        }

        private static IEnumerable<string> SeperateNumbers(string input)
        {
            return input.Split(GetDelimiters(), StringSplitOptions.RemoveEmptyEntries);
        }

        private static char[] GetDelimiters()
        {
            return new[] { ',', '\n' };
        }

        private static bool EmptyString(string input)
        {
            return input == String.Empty;
        }
    }
}
