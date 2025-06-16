// Usando o framework de testes do C# .NET
using Xunit;

// Usando o namespace para chamar a classe a ser testada
using NumberToRoman;

// Definindo o namespace para a classe de testes
namespace NumberToRoman.Tests;

public class NumberToRomanTests
{
    // Diz que é um teste unitário único, sem parâmetros
    [Fact]

    // Método de teste que verifica a conversão do número 1 para o numeral romano "I"
    public void Convert1ToI()
    {
        // Entrada do teste
        int input = 1; 
        // Resultado esperado da conversão
        string expected = "I";

        // Resultado guarda o valor retornado pelo método Converter da classe NumberToRoman
        var result = NumberToRoman.Convert(input);

        // Assert verifica se o resultado é válido
        // Isso pode ser se é igual (Equal(esperado, atual)), verdadeiro (True(condição)), não nulo (NotNull(obj))
        Assert.Equal(expected, result);
    }

    // Modo de testar vários valores em uma única função
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]

    public void ConvertNumbersToRomain(int input, string expected)
    {
        var result = NumberToRoman.Convert(input);

        Assert.Equal(expected, result);
    }

    // Teste para verificar se as exceções são lançadas corretamente
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(4000)]

    public void VerifyValidNumber(int input) {
        // O xUnit espera que a função VerifyNumber lance uma exceção ArgumentOutOfRangeException, pois recebeu um número inválido
        Assert.Throws<ArgumentOutOfRangeException>(() => NumberToRoman.VerifyNumber(input));
    }

    // Teste para a função SortNumber, uma classificadora de casas decimais
    [Theory]
    [InlineData(1, "Unidade")]
    [InlineData(10, "Dezena")]
    [InlineData(100, "Centena")]
    [InlineData(1000, "Milhar")]

    public void VerifySortNumber(int input, string expected)
    {
        // Cria uma instância da classe NumberToRoman
        var numberToRoman = new NumberToRoman(input);
        
        // Chama o método SortNumber e armazena o resultado
        var result = numberToRoman.SortNumber(input);

        // Verifica se o resultado contém a string esperada, não precisa ser IGUAL apenas se contém
        Assert.Contains(expected, result);
    }
}