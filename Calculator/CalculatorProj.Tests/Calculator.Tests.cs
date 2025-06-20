namespace CalculatorProj.Tests;
using CalculatorApp;

public class CalculatorTests
{
    // Test cases for the Calculator class methods

    [Theory]
    //[InlineData(numberOne, numberTwo, resultExpected)]
    [InlineData(1, 2, 3)]
    [InlineData(5, 7, 12)]
    [InlineData(10, 20, 30)]

    public void TestAdd(float numberOne, float numberTwo, float resultExpected)
    {
        Calculator calculator = new Calculator();
        float resultOperation = calculator.Add(numberOne, numberTwo);
        Assert.Equal(resultExpected, resultOperation);
    }

    [Theory]
    [InlineData(5, 2, 3)]
    [InlineData(8, 1, 7)]
    [InlineData(10, 4, 6)]

    public void TestSubtract(float numberOne, float numberTwo, float resultExpected)
    {
        Calculator calculator = new Calculator();
        float resultOperation = calculator.Subtract(numberOne, numberTwo);
        Assert.Equal(resultExpected, resultOperation);
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(5, 7, 35)]
    [InlineData(10, 20, 200)]

    public void TestMultiply(float numberOne, float numberTwo, float resultExpected)
    {
        Calculator calculator = new Calculator();
        float resultOperation = calculator.Multiply(numberOne, numberTwo);
        Assert.Equal(resultExpected, resultOperation);
    }

    [Theory]
    [InlineData(2, 1, 2)]
    [InlineData(6, 2, 3)]
    [InlineData(20, 10, 2)]

    public void TestDivide(float numberOne, float numberTwo, float resultExpected)
    {
        Calculator calculator = new Calculator();
        float resultOperation = calculator.Divide(numberOne, numberTwo);
        Assert.Equal(resultExpected, resultOperation);
    }

    [Fact]
    public void TestDivideByZero()
    {
        Calculator calculator = new Calculator();
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }

    [Theory]
    [InlineData(2, 3, 8)]
    [InlineData(5, 2, 25)]
    [InlineData(3, 4, 81)]
    [InlineData(10, 0, 1)]

    public void TestExponent(float baseNum, float exponent, float resultExpected)
    {
        Calculator calculator = new Calculator();
        float resultOperation = calculator.Exponent(baseNum, exponent);
        Assert.Equal(resultExpected, resultOperation);
    }

    [Theory]
    [InlineData(4, 2)]
    [InlineData(9, 3)]
    [InlineData(16, 4)]
    [InlineData(-25, 0)]

    public void TestSquareRoot(float number, float resultExpected)
    {
        Calculator calculator = new Calculator();
        if (number < 0)
        {
            Assert.Throws<ArgumentException>(() => calculator.SquareRoot(number));
        }
        else
        {
            float resultOperation = calculator.SquareRoot(number);
            Assert.Equal(resultExpected, resultOperation);
        }
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 6)]
    [InlineData(4, 24)]
    [InlineData(5, 120)]

    public void TestFactorial(int number, float resultExpected) {
        Calculator calculator = new Calculator();

        if(number < 0) {
            Assert.Throws<ArgumentException>(() => calculator.Factorial(number));
        } else {
            float resultOperation = calculator.Factorial(number);
            Assert.Equal(resultExpected, resultOperation);
        }
    }

    [Theory]
    [InlineData(100, 10, 2)]
    [InlineData(1000, 10, 3)]

    public void TestLogarithms(float number, float baseNum, float resultExpected)
    {
        Calculator calculator = new Calculator();
        if (number <= 0 || baseNum <= 0 || baseNum == 1)
        {
            Assert.Throws<ArgumentException>(() => calculator.Logarithms(number, baseNum));
        }
        else
        {
            float resultOperation = calculator.Logarithms(number, baseNum);
            Assert.Equal(resultExpected, resultOperation);
        }
    }
}