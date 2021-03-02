using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add(string stringToConvert)
        {
            // If string is empty return 0
            if (stringToConvert == "") return 0;
            
            // If string contains "//" use delimiter that follows, else use "," & "\n"
            string[] stringsToInt;
            if (stringToConvert.Contains("//"))
            {
                string delimiter = Regex.Match(stringToConvert, @"(?<=\/\/).").ToString();
                string substringToConvert = Regex.Match(stringToConvert, @"(?<=\n).*").ToString();
                stringsToInt = substringToConvert.Split(delimiter);
            }
            else
            {
                stringsToInt = Regex.Split(stringToConvert, @"[\n,]+");
            }
    
            // Loop through array of strings and convert to int
            int[] numbers = new int[stringsToInt.Length];
            for (int i = 0; i < stringsToInt.Length; i++)
            {
                numbers[i] = Int32.Parse(stringsToInt[i]);
            }

            return numbers.Sum();
        }
    }
}