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
        // Resultado guarda o valor retornado pelo método Converter da classe NumberToRoman
        var resultado = NumberToRoman.Converter(1);

        // Assert verifica se o resultado é válido
        // Isso pode ser se é igual (Equal(esperado, atual)), verdadeiro (True(condição)), não nulo (NotNull(obj))
        Assert.Equal("I", resultado);
    }

    // Modo de testar vários valores em uma única função
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]

    public void ConvertNumbersToRomain(int input, string expected)
    {
        var resultado = NumberToRoman.Converter(input);
        Assert.Equal(expected, resultado);
    }
}