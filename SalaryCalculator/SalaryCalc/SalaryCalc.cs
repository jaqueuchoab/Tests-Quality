using System;
using Models;
namespace Servises;

public class SalaryCalc {
  private Funcionario funcionario;

  public SalaryCalc(Funcionario funcionario = null) {
    if (funcionario == null) {
      throw new ArgumentNullException(nameof(funcionario), "Funcionário não pode ser nulo.");
    }

    this.funcionario = funcionario;
  }

  public int ClassificarDesconto() {
    double salario = this.funcionario.Salario;
    string cargo = this.funcionario.Cargo;

    switch (cargo.ToUpper())
    {
      case "DESENVOLVEDOR":
        return (salario >= 13000) ? 20 : 10;
        break;
      case "DBA":
        return (salario >= 15000) ? 25 : 15;
        break;
      case "TESTADOR":
        return (salario >= 15000) ? 25 : 15;
        break;
      case "GERENTE":
        return (salario >= 18000) ? 30 : 20;
        break;
      default:
        throw new ArgumentException("Cargo inválido ou não suportado.");
    }
  }

  public double CalcularSalarioLiquido() {
    double salario = this.funcionario.Salario;
    int desconto = ClassificarDesconto();

    double valorDesconto = (salario * desconto) / 100;
    double salarioLiquido = salario - valorDesconto;

    return salarioLiquido;
  }
}