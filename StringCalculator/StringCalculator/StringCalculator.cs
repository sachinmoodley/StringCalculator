using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (EmptyString(input)) return 0;
            var convertedNumber = AddConvertedNumbersToList(input);
            ThrowsExceptionIfContainsNegatives(convertedNumber);

            return convertedNumber.Sum();
        }
        
        private static void ThrowsExceptionIfContainsNegatives(IEnumerable<int> negatives)
        {
            var negativeNumbers = GetNegativeNumbers(negatives);
            if (negativeNumbers.Any())
            {
                var negativeString = string.Join(",", negativeNumbers);
                throw new Exception($"Negatives not allowed :{negativeString}");
            }
        }

        private static List<int> GetNegativeNumbers(IEnumerable<int> convertedNumber)
        {
            return convertedNumber.Where(x => x < 0).ToList();
        }

        private static bool StartsWithDoubleSlashes(string input)
        {
            return input.StartsWith("//");
        }

        private static char[] GetUnknownDelimiter(string input)
        {
            var start = input.IndexOf("//");
            var end = input.IndexOf("\n");
            var beginingOfInput = input.Substring(start, end - start);

            return beginingOfInput.ToCharArray();
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
            var delimiter = GetDelimiters(input);
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }

        private static char[] GetDelimiters(string input)
        {
            if (StartsWithDoubleSlashes(input))
            {
                return GetUnknownDelimiter(input);
            }
            return new[] { ',', '\n' };
        }
        
        private static bool EmptyString(string input)
        {
            return input == string.Empty;
        }
    }
}
