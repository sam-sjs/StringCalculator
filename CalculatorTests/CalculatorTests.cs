using System;
using Xunit;
using StringCalculator;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Test_Output_Is_Number()
        {
            // Arrange
            string input = "";

            // Act
            int output = Calculator.Add(input);

            // Assert
            Assert.IsType<Int32>(output);
        }

        [Fact]
        public void Test_Output_Value_Is_Correct()
        {
            // Arrange
            string input = "5";
            int expectedOutput = 5;

            // Act
            int output = Calculator.Add(input);

            // Assert
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Test_Can_Sum_Two_Numbers()
        {
            // Arrange
            string input = "3,5";
            int expectedOutput = 8;
            
            // Act
            int output = Calculator.Add(input);
            
            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}