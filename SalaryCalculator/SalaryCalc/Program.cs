using System;
using Models;
using Servises;

class Program {
  public static void Main(string[] args) {
    try {
      Console.WriteLine("Insira abaixo as informações do funcionário");
      Console.WriteLine("------------------------------");
      Console.Write("Nome: ");
      string nome = Console.ReadLine();
      Console.Write("Salário: ");
      double salario = Convert.ToDouble(Console.ReadLine());
      Console.Write("Cargo: ");
      string cargo = Console.ReadLine();
      Console.WriteLine("------------------------------");

      Funcionario funcionario = new Funcionario(nome, salario, cargo);
      SalaryCalc salaryCalc = new SalaryCalc(funcionario);
      double salarioLiquido = salaryCalc.CalcularSalarioLiquido();

      Console.WriteLine("------------------------------");
      Console.WriteLine($"Funcionário: {funcionario.Nome}\nCargo: ({funcionario.Cargo})\nSalário Líquido: R$ {salarioLiquido:F2}");
      Console.WriteLine("------------------------------");
    } catch(Exception ex) {
      Console.WriteLine($"Ops, temos um erro: {ex.Message}");
    }
  }
}