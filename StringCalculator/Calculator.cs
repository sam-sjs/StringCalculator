using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add(string stringToConvert)
        {
            if (stringToConvert == "") return 0;

            string[] stringsToInt = Regex.Split(stringToConvert, @"[\n,]+");
            int[] numbers = new int[stringsToInt.Length];
            
            for (int i = 0; i < stringsToInt.Length; i++)
            {
                numbers[i] = Int32.Parse(stringsToInt[i]);
            }

            return numbers.Sum();
        }
    }
}