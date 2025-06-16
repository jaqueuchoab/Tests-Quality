### Customização de saídas | Testes em xUnit

> A fim de exibir mensagens mais detalhadas em testes a customização permitirá uma melhor personalização das saídas.

<b>Exemplo de uso: (Confira a explicação detalhada abaixo)</b>

```
using Xunit;
using Xunit.Abstractions;

public class NumberToRomanTests
{
    private readonly ITestOutputHelper _output;

    public NumberToRomanTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Theory]
    [InlineData(1, "I")]
    public void TestaConversaoComSaida(int input, string esperado)
    {
        var resultado = NumberToRoman.Converter(input);

        // Mensagem customizada no console
        _output.WriteLine($"Entrada: {input} | Resultado: {resultado} | Esperado: {esperado}");

        Assert.Equal(esperado, resultado);
    }
}
```

`using Xunit.Abstractions;` &rarr; É um pacote interno do xUnit que define interfaces e contratos compartilhados sem depender diretamente do framework.

`private readonly ITestOutputHelper _output;` &rarr; Define uma variável com o nome `_output` que armazena a instância do `ITestOutputHelper`, uma interface usada para escrever mensagens durante a execução dos testes. `private readonly` define que essa variável só pode ser acessada dentro da classe `NumberToRomanTests` e que a atribuição de valor ocorre apenas uma vez, normalmente no construtor da classe como indica no código acima.

`_output.WriteLine($"Entrada: {input} | Resultado: {resultado} | Esperado: {esperado}");`&rarr; Customização da saída.

OBS: Isso não pode ser feito pelo Console.WriteLine() pois o xUnit não aceita.

<b>Testando as saídas</b>
`dotnet test -v n`
Esse comando irá garantir que as saídas sejam impressas no terminal na execução do teste.
