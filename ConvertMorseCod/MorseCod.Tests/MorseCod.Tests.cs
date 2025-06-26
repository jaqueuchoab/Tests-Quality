namespace MorseCod.Tests;

public class UnitTest1
{
    [Fact]
    public void TestClassConvertMorseCod()
    {
        string frase = "oi vi";
        string resultadoEsperado = "--- .. ...- ..";

        var convert = new ConvertMorseCod(frase);
        string resultado = convert.StringToMorse();

        Assert.Equal(resultadoEsperado, resultado);
    }

    // Testes em exceções
    [Fact]
    public void TestClassConvertMorseCodFraseNula()
    {
        Assert.Throws<ArgumentException>(() => new ConvertMorseCod(null));
    }

    // Cases de teste
    [Theory]
    [InlineData("bom dia", "-... --- -- -.. .. .-")]
    [InlineData("tudo bem", "- ..- -.. --- -... . --")]
    [InlineData("fique em casa", "..-. .. --.- ..- . . -- -.-. .- ... .-")]

    public void TestClassConvertMorseCodFrase(string frase, string resultadoEsperado)
    {
        var convert = new ConvertMorseCod(frase);
        string resultado = convert.StringToMorse();

        Assert.Equal(resultadoEsperado, resultado);
    }
}