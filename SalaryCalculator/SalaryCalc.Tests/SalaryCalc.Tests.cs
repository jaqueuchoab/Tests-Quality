namespace SalaryCalc.Tests;
using Models;
using Servises;

public class SalaryCalcTests
{
    // Testando classe Funcionario
    [Fact]
    public void TestClassFuncionario() {
        var funcionario = new Funcionario("João Batista", 3500, "Desenvolvedor");

        string nome = funcionario.Nome;
        double salario = funcionario.Salario;
        string cargo = funcionario.Cargo;

        Assert.Equal("João Batista", nome);
        Assert.Equal(3500, salario);
        Assert.Equal("Desenvolvedor", cargo);
    }

    // Testando classe SalaryCalc com case específico
    [Fact]
    public void TestClassSalaryCalc() {
        var funcionario = new Funcionario("Maria Silva", 15000, "Gerente");
        var salaryCalc = new SalaryCalc(funcionario);

        double salario = salaryCalc.CalcularSalarioLiquido();

        Assert.Equal(12000, salario);
    }

    // Testando classe SalaryCalc com diferentes casos
    [Theory]
    [InlineData("Jordan", 18000, "Desenvolvedor", 14400)]
    [InlineData("Jaqueline", 20000, "Testador", 15000)]
    [InlineData("Isabel", 19000, "DBA", 14250)]

    public void TestClassSalaryCalcCases(string nome, double salario, string cargo, double expected)
    {
        var funcionario = new Funcionario(nome, salario, cargo);
        var salaryCalc = new SalaryCalc(funcionario);

        double resultado = salaryCalc.CalcularSalarioLiquido();

        Assert.Equal(expected, resultado);
    }

    // Testando exceção na classe SalaryCalc
    [Fact]
    public void TestClassSalaryCalcException()
    {
        var salaryCalc = Assert.Throws< ArgumentNullException>(() => new SalaryCalc());
    }

    // Testando exceção de cargo invalido
    [Fact]
    public void TestClassSalaryCalcExceptionInvalidCargo()
    {
        var funcionario = new Funcionario("Carlos", 20000, "QA");
        var salaryCalc = new SalaryCalc(funcionario);

        var exception = Assert.Throws<ArgumentException>(() => salaryCalc.ClassificarDesconto());
    }

    // Testando exceção de funcionario nulo
    [Fact]
    public void TestClassSalaryCalcExceptionFuncionarioNull()
    {
        var salaryCalc = Assert.Throws<ArgumentNullException>(() => new SalaryCalc());
    }
}