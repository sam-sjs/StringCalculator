using System;
using System.Linq;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add(string toConvert)
        {
            if (toConvert == "") return 0; // This seems like a poor solution but works for now

            string[] stringsToInt = toConvert.Split(",");
            int[] toSum = new int[stringsToInt.Length];
            for (int i = 0; i < stringsToInt.Length; i++)
            {
                toSum[i] = Int32.Parse(stringsToInt[i]);
            }

            return toSum.Sum();
        }
    }
}