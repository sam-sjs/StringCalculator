using System;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Calculate(string toConvert)
        {
            if (toConvert == "") return 0; // This seems like a poor solution but works for now
            return Int32.Parse(toConvert);
        }
    }
}