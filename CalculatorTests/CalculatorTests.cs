using System;
using Xunit;
using StringCalculator;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("5", 5)]
        [InlineData("3,5", 8)]
        [InlineData("3,5,3,9", 20)]
        [InlineData("3,4\n3,5", 15)]
        [InlineData("//;\n4;5", 9)]
        [InlineData("1000,1001,2", 2)]
        [InlineData("//[***]\n1***2***3", 6)]
        [InlineData("//[*][%]\n1*2%3", 6)]
        [InlineData("//[***][#][%]\n1***2#3%4", 10)]
        [InlineData("//[*1*][%]\n1*1*2%3", 6)]
        public void Sums_Input_Sting(string input, int expectedOutput)
        {
            int output = Calculator.Add(input);

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Output_Is_Number()
        {
            string input = "";

            int output = Calculator.Add(input);

            Assert.IsType<Int32>(output);
        }

        [Fact]
        public void Does_Not_Allow_Negative_Numbers()
        {
            string input = "-1,2,-3";
            string message = "Negatives not allowed: -1, -3";
            
            var exception = Assert.Throws<ArgumentException>(() => Calculator.Add(input));
            Assert.Equal(message, exception.Message);
        }
        
        [Fact]
        public void Numeric_Edge_Causes_Exception()
        {
            string input = "//[1**][%]\n1*1*2%3";

            Assert.Throws<ArgumentException>(() => Calculator.Add(input));
        }
    }
}