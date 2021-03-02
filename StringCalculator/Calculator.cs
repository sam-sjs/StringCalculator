using System;
using System.Collections.Generic;
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
            if (Regex.Match(stringToConvert, @"(^\/\/\[).*?\]").Length > 0)
            {
                // This can definitely be refactored with the below condition
                string delimiter = Regex.Match(stringToConvert, @"(?<=\/\/\[)(.*)(?=\])").ToString();
                string substringToConvert = Regex.Match(stringToConvert, @"(?<=\n).*").ToString();
                stringsToInt = substringToConvert.Split(delimiter);
            }
            else if (stringToConvert.Contains("//"))
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
            List<int> posNumbers = new List<int>();
            List<int> negNumbers = new List<int>();
            for (int i = 0; i < stringsToInt.Length; i++)
            {
                // Only sum positive numbers less than 1000
                int currentNumber = Int32.Parse(stringsToInt[i]);
                if (currentNumber >= 0 && currentNumber < 1000)
                {
                    posNumbers.Add(currentNumber);    
                }
                else if (currentNumber < 0)
                {
                    negNumbers.Add(currentNumber);
                }
            }

            if (negNumbers.Count > 0)
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ",negNumbers.ToArray())}");
            }
            
            return posNumbers.Sum();
        }
    }
}