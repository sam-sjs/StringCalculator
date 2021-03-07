using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add(string stringToCalculate)
        {
            if (stringToCalculate == "") return 0;
            
            string[] valuesToConvert = FindValues(stringToCalculate);

            return StringsToInt(valuesToConvert).Sum();
        }

        private static string[] FindValues(string input)
        {
            string[] delimiter1 = Regex.Matches(input, @"\[([^]]+)\]")
                .Select(m => m.Groups[1].Value)
                .ToArray();
            string[] delimiter2 = Regex.Matches(input, @"(?<=\/\/).")
                .Select(m => m.Value)
                .ToArray();
            string delimiter3 = @"[\n,]+";
            string substringToConvert = Regex.Match(input, @"(?<=\n).*").ToString();
            
            if (Regex.Match(input, @"(^\/\/\[).*?\]").Length > 0)
            {
                return substringToConvert.Split(delimiter1, StringSplitOptions.RemoveEmptyEntries);
            }
            
            if (input.Contains("//"))
            {
                return substringToConvert.Split(delimiter2, StringSplitOptions.RemoveEmptyEntries);
            }
            
            return Regex.Split(input, delimiter3);
        }

        private static List<int> StringsToInt(string[] valuesToConvert)
        {
            List<int> posNumbers = new List<int>();
            List<int> negNumbers = new List<int>();
            foreach (string value in valuesToConvert)
            {
                int currentNumber = Int32.Parse(value);
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

            return posNumbers;
        }
    }
}

//;\n1;2
//[***]\n1***2***3
//[*][%]\n1*2%3
//[***][#][%]\n1***2#3%4


// (?(?<=\/\/)(.))
//     \[(.*?)\]|\/\/(.*?)\\n
//     \/\/(.*?)\\n
//     
//     (?(?=\/\/\[.*)\/\/\[(.*?)\]|\/\/.*\\n)

// This might work - Group 1 & 2
// \[([^]]+)\]|(?(?=\/\/.\\n)\/\/(.))

// (?(?=\/\/\[)\[([^]]+)\]|(?<=\/\/).)
// \[([^\d][^]][^\d]+?)\]

// Closest so far
// \[(\D+?[^]]*\D?)\]

// \[(?(?=\D+)([^]]*\D))\]  -- seems like it should be working

// \[(?(?=\D+)([^]]*\D))\]