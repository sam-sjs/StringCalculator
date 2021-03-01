using System;
using Xunit;
using StringCalculator;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        [Fact]
        // Refactor to [THEORY]
        
        // Step One
        public void Test_Output_Is_Number()
        {
            // Arrange
            string input = "";

            // Act
            int output = Calculator.Add(input);

            // Assert
            Assert.IsType<Int32>(output);
        }
        
        // Step Two 
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
        
        // Step Three
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

        // Step Four
        [Fact]
        public void Test_Can_Take_Varying_Length_Inputs()
        {
            // Arrange
            string input = "3,5,3,9";
            int expectedOutput = 20;
            
            // Act
            int output = Calculator.Add(input);
            
            // Assert
            Assert.Equal(expectedOutput, output);
        }
        
        // Step Five
        [Fact]
        public void Test_Can_Vary_Line_Breaks_And_Commas()
        {
            // Arrange
            string input = "3,4\n3,5";
            int expectedOutput = 15;
            
            // Act
            int output = Calculator.Add(input);
            
            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}