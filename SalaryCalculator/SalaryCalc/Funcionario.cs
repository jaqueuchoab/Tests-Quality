using System;
namespace Models;

public class Funcionario {
    public string Nome { get; private set; }
    public double Salario { get; private set; }
    public string Cargo { get; private set; }

    public Funcionario(string nome = null, double salario = 0, string cargo = null) {
      if(nome == null || salario == 0 || cargo == null) {
        throw new ArgumentNullException("As credenciais do funcionário não podem ser nulas.");
      }
      this.Nome = nome;
      this.Salario = salario;
      this.Cargo = cargo;
    }
}