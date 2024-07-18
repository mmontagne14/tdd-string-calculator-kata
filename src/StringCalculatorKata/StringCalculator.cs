using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            int res = 0;
            if (string.IsNullOrEmpty(numbers))
                return res;

            if (int.TryParse(numbers, out res))
                return res;

            foreach (int number in ExtractIntArray(numbers))
            {
                res += number;
            }
            return res;
        }

        public static List<int> ExtractIntArray(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                char delimiter = numbers[3];
                int lineIndex = numbers.IndexOf("\n");
                return numbers.Substring(lineIndex + 1).Replace('\n', delimiter).Split(delimiter).Select(x => int.Parse(x)).ToList();
            }

            return numbers.Replace("\n", ",").Split(",").Select(x => int.Parse(x)).ToList();
        }
    }
}
