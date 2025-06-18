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
    public void Convert1ToI() {
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

    public void ConvertNumbersToRomain(int input, string expected) {
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

    public void VerifySortNumber(int input, string expected) {
        // Cria uma instância da classe NumberToRoman
        var numberToRoman = new NumberToRoman(input);
        
        // Chama o método SortNumber e armazena o resultado
        var result = numberToRoman.SortNumber(input);

        // Verifica se o resultado contém a string esperada, não precisa ser IGUAL apenas se contém
        Assert.Contains(expected, result);
    }

    // Teste para verificar a conversão de números com apenas uma unidade
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    [InlineData(9, "IX")]

    public void ConvertUnitRoman(int number, string expected) {
        NumberToRoman numberToRoman = new NumberToRoman(number);

        // Verificar se o número é uma unidade
        numberToRoman.SortNumber(number);
        var result = numberToRoman.GetNumberConverted();
        Assert.Equal(expected, result);
    }

    [Theory]
    // Casos base
    [InlineData(10, "X")]
    [InlineData(20, "XX")]
    [InlineData(30, "XXX")]
    [InlineData(40, "XL")]
    [InlineData(50, "L")]
    [InlineData(60, "LX")]
    [InlineData(70, "LXX")]
    [InlineData(80, "LXXX")]
    [InlineData(90, "XC")]
    // Casos que entram na primeira condição do método Dezena
    [InlineData(11, "XI")]
    [InlineData(14, "XIV")]
    [InlineData(19, "XIX")]
    [InlineData(21, "XXI")] 
    [InlineData(24, "XXIV")]
    [InlineData(29, "XXIX")]
    [InlineData(31, "XXXI")]
    [InlineData(34, "XXXIV")]
    [InlineData(39, "XXXIX")]
    // Casos que entram na segunda condição do método Dezena
    [InlineData(51, "LI")]
    [InlineData(54, "LIV")]
    [InlineData(59, "LIX")]
    // Casos que entram na terceira condição do método Dezena
    [InlineData(61, "LXI")]
    [InlineData(64, "LXIV")]
    [InlineData(69, "LXIX")]
    [InlineData(71, "LXXI")]
    [InlineData(74, "LXXIV")]
    [InlineData(79, "LXXIX")]
    [InlineData(81, "LXXXI")]
    [InlineData(84, "LXXXIV")]
    [InlineData(89, "LXXXIX")]
    // Casos que entram no else, ou seja, casos especiais que adicionam "X" antes do resultado
    [InlineData(41, "XLI")]
    [InlineData(44, "XLIV")]
    [InlineData(49, "XLIX")]
    [InlineData(91, "XCI")]
    [InlineData(94, "XCIV")]
    [InlineData(99, "XCIX")]

    public void ConvertTensRoman(int number, string expected) {
        NumberToRoman numberToRoman = new NumberToRoman(number);

        // Verificar se o número é uma dezena
        numberToRoman.SortNumber(number);
        var result = numberToRoman.GetNumberConverted();
        Assert.Equal(expected, result);
    }

    [Theory]
    // Casos base
    [InlineData(100, "C")]
    [InlineData(200, "CC")]
    [InlineData(300, "CCC")]
    [InlineData(400, "CD")]
    [InlineData(500, "D")]
    [InlineData(600, "DC")]
    [InlineData(700, "DCC")]
    [InlineData(800, "DCCC")]
    [InlineData(900, "CM")]
    // Casos que entram na primeira condição do método Centena
    [InlineData(101, "CI")]
    [InlineData(104, "CIV")]
    [InlineData(109, "CIX")]
    // Casos que entram no else, ou seja, casos especiais que adicionam "C" antes do resultado
    [InlineData(401, "CCI")]
    [InlineData(404, "CCIV")]
    [InlineData(409, "CCIX")]
    [InlineData(901, "CMI")]
    [InlineData(904, "CMIV")]
    [InlineData(909, "CMIX")]



    public void ConvertHundredsRoman(int number, string expected) {
        NumberToRoman numberToRoman = new NumberToRoman(number);

        // Verificar se o número é uma centena
        numberToRoman.SortNumber(number);
        var result = numberToRoman.GetNumberConverted();
        Assert.Equal(expected, result);
    }
}