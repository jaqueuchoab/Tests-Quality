using System;
namespace CalculatorApp;

public class Calculator {
  private string operation;

  public Calculator() {
    this.operation = "None";
  }

  // Basic arithmetic operations
  public float Add(float a, float b) {
    this.operation = "Addition";
    return a + b;
  }

  public float Subtract(float a, float b) {
    this.operation = "Subtraction";
    return a - b;
  }

  public float Multiply(float a, float b) {
    this.operation = "Multiplication";
    return a * b;
  }

  public float Divide(float a, float b) {
    if (b == 0) {
      throw new DivideByZeroException("Cannot divide by zero.");
    }
    this.operation = "Division";
    return a / b;
  }

  // Advanced mathematical operations
  public float Exponent(float baseNum, float exponent) {
    this.operation = "Exponentiation";
    return (float)Math.Pow(baseNum, exponent);
  }

  public float SquareRoot(float number) {
    if (number < 0) {
      throw new ArgumentException("Cannot calculate square root of a negative number.");
    }
    this.operation = "Square Root";
    return (float)Math.Sqrt(number);
  }

  public float Factorial(int number) {
    if (number < 0) {
      throw new ArgumentException("Cannot calculate factorial of a negative number.");
    }
    this.operation = "Factorial";
    float result = 1;
    for (int i = 1; i <= number; i++) {
      result *= i;
    }
    return result;
  }

  public float Logarithms(float number, float baseNum) {
    if (number <= 0 || baseNum <= 0 || baseNum == 1) {
      throw new ArgumentException("Invalid input for logarithm.");
    }
    this.operation = "Logarithm";
    return (float)(Math.Log(number) / Math.Log(baseNum));
  }

  public string GetOperation() {
    return this.operation;
  }

}