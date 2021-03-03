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
        public void Output_Is_Number()
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
        public void Output_Value_Is_Correct()
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
        public void Can_Sum_Two_Numbers()
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
        public void Can_Take_Varying_Length_Inputs()
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
        public void Can_Vary_Line_Breaks_And_Commas()
        {
            // Arrange
            string input = "3,4\n3,5";
            int expectedOutput = 15;
            
            // Act
            int output = Calculator.Add(input);
            
            // Assert
            Assert.Equal(expectedOutput, output);
        }
        
        // Step Six
        [Fact]
        public void Can_Accept_Custom_Delimiter()
        {
            // Arrange
            string input = "//;\n4;5";
            int expectedOutput = 9;
            
            // Act
            int output = Calculator.Add(input);
            
            // Assert
            Assert.Equal(expectedOutput, output);
        }
        
        // Step Seven
        [Fact]
        public void Does_Not_Allow_Negative_Numbers()
        {
            // Arrange
            string input = "-1,2,-3";
            string message = "Negatives not allowed: -1, -3";
            
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => Calculator.Add(input));
            Assert.Equal(message, exception.Message);
        }
        
        // Step Eight
        [Fact]
        public void Does_Not_Allow_Greater_Than_1000()
        {
            // Arrange
            string input = "1000,1001,2";
            int expectedOutput = 2;
            
            // Act
            int output = Calculator.Add(input);
            
            // Assert
            Assert.Equal(expectedOutput, output);
        }
        
        // Step Nine
        [Fact]
        public void Can_Accept_Any_Length_Delimiter()
        {
            // Arrange
            string input = "//[***]\n1***2***3";
            int expectedOutput = 6;
            
            // Act
            int output = Calculator.Add(input);
            
            // Assert
            Assert.Equal(expectedOutput, output);
        }
        
        // Step Ten
        [Fact]
        public void Can_Accept_Multiple_Delimiters()
        {
            // Arrange
            string input = "//[*][%]\n1*2%3";
            int expectedOutput = 6;
            
            // Act
            int output = Calculator.Add(input);
            
            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}