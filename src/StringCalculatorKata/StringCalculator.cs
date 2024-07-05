using System;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Linq;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Length == 0)
                return 0;

            char delimiter = ',';
            if (numbers.Contains("//"))
            {
                numbers = ExtractDelimiter(numbers, out delimiter);
            };
            var numbersArray = SplitByDelimiter(numbers, delimiter);

            DetectNegativeNumbers(numbersArray);

            return numbers.Replace('\n', delimiter).Split(delimiter).Select(x => int.Parse(x)).Sum();
        }

        private static string[] SplitByDelimiter(string numbers, char delimiter)
        {
            return numbers.Replace('\n', delimiter).Split(delimiter);
        }

        private static string ExtractDelimiter(string numbers, out char defaultDelimiter)
        {
            defaultDelimiter = numbers.ToCharArray()[2];
            return numbers[4..];
        }

        private static void DetectNegativeNumbers(string[] numbersArray)
        {
            if (numbersArray.Any(x => int.Parse(x) < 0))
            {
                var negativeNumberList = numbersArray.Where(x => int.Parse(x) < 0).ToList();
                var sb = new System.Text.StringBuilder();
                negativeNumberList.ForEach(x =>
                {
                    string negativeNumberToAdd = String.Format(int.Parse(x) + " ");
                    sb.Append(negativeNumberToAdd);
                });
                throw new ArgumentException(String.Format("negatives not allowed : {0}", sb.ToString()));
            }
        }
    }
}
