using System;
using CalculatorApp;

class Program {
  static void Main(string[] args) {
    Calculator calculator = new Calculator();

    Console.WriteLine("Bem-vindo à Calculadora!");
    Console.WriteLine("Escolha uma operação:");
    Console.WriteLine("1. Adição");
    Console.WriteLine("2. Subtração");
    Console.WriteLine("3. Multiplicação");
    Console.WriteLine("4. Divisão");
    Console.WriteLine("5. Exponenciação");
    Console.WriteLine("6. Raiz Quadrada");
    Console.WriteLine("7. Fatorial");
    Console.WriteLine("0. Sair");


    do {
      Console.Write("\nDigite o número da operação: ");
      int choice = int.Parse(Console.ReadLine());

      if (choice == 0) {
        Console.WriteLine("Saindo do programa...");
        break;
      }

      float num1, num2, result;

      switch (choice) {
        case 1:
          Console.Write("Digite o primeiro número: ");
          num1 = float.Parse(Console.ReadLine());
          Console.Write("Digite o segundo número: ");
          num2 = float.Parse(Console.ReadLine());
          result = calculator.Add(num1, num2);
          Console.WriteLine($"Resultado: {result}");
          break;
        case 2:
          Console.Write("Digite o primeiro número: ");
          num1 = float.Parse(Console.ReadLine());
          Console.Write("Digite o segundo número: ");
          num2 = float.Parse(Console.ReadLine());
          result = calculator.Subtract(num1, num2);
          Console.WriteLine($"Resultado: {result}");
          break;
        case 3:
          Console.Write("Digite o primeiro número: ");
          num1 = float.Parse(Console.ReadLine());
          Console.Write("Digite o segundo número: ");
          num2 = float.Parse(Console.ReadLine());
          result = calculator.Multiply(num1, num2);
          Console.WriteLine($"Resultado: {result}");
          break;
        case 4:
          Console.Write("Digite o primeiro número: ");
          num1 = float.Parse(Console.ReadLine());
          Console.Write("Digite o segundo número: ");
          num2 = float.Parse(Console.ReadLine());
          // try catch for division by zero
          try {
            result = calculator.Divide(num1, num2);
            Console.WriteLine($"Resultado: {result}");
          } catch (DivideByZeroException e) {
            Console.WriteLine(e.Message);
          }
          break;
        case 5:
          Console.Write("Digite a base: ");
          num1 = float.Parse(Console.ReadLine());
          Console.Write("Digite o expoente: ");
          num2 = float.Parse(Console.ReadLine());
          result = calculator.Exponent(num1, num2);
          Console.WriteLine($"Resultado: {result}");
          break;
        case 6:
          Console.Write("Digite o número: ");
          num1 = float.Parse(Console.ReadLine());
          // try catch for negative numbers
          try {
            result = calculator.SquareRoot(num1);
            Console.WriteLine($"Resultado: {result}");
          } catch (ArgumentException e) {
            Console.WriteLine(e.Message);
          }
          break;
        case 7:
          Console.Write("Digite o número: ");
          int number = int.Parse(Console.ReadLine());
          // try catch for negative numbers
          try {
            result = calculator.Factorial(number);
            Console.WriteLine($"Resultado: {result}");
          } catch (ArgumentException e) {
            Console.WriteLine(e.Message);
          }
          break;
        default:
          Console.WriteLine("Opção inválida. Tente novamente.");
          break;
      }
    } while (true);
  }
}