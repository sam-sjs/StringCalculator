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
            int output = Calculator.Calculate(input);
            
            // Assert
            Assert.IsType<Int32>(output);
        }
    }
}