### Questão 2 - Converter números base 10 em romanos

<b>1.  Verificar a casa decimal do número total:</b>
    <b>2424</b>: 3 digitos após o primeiro número = MILHAR (1000)

    - Nenhum digito (UND) | <b>I - V - IX</b>
    - 1 digito (DEZENA)   | <b>X</b>
    - 2 digitos (CENTENA) | <b>C</b> 
    - 3 digitos (MILHAR)  | <b>M</b>

<b>2.  Definir o símbolo geral com base na casa decimal:</b>

MILHAR == M

<b>3.  Verificar a quantidade de vezes que o símbolo principal (casa decimal) vai se repetir:</b>

A partir do primeiro algorismos do número multiplicar o símbolo: 

> No caso do número <b>2424</b> o <b>"2"</b> é o primeiro algorismos e o símbolo da casa é M, logo, será <b>MM</b>

<b>Verificações Importantes</b>

> Um mesmo símbolo não se repete MAIS de 3 vezes;

> O símbolo da *próxima casa a ser encontrada* na hierarquia à atual é colocada antes à *atual*;

> Casos especiais, 4 e 9, símbolos com a lógica anterior;

> Casos especiais, 1 e 5, símbolos específicos;

    Exemplo:
    400 = 2 digitos (CENTENA = C)
    ↳ 4 x C == CCCC ❌
    ↳ Adiciona mais uma casa decimal (CENTENA = 100) 
    | 400 + 100 = 500 (SÍMBOLO = D) -> Válido
    ↳ Lógica: Sequência o símbolo da casa decimal *atual* (C) e logo após o mais válido (D)
    | CD é como se fosse, 100 - 500 = -400 mas positivo.

    90 = 1 digito (DEZENA = X) 
    ↳ 9 x X === XXXXXXXXX ❌
    ↳ Adiciona mais uma casa decimal (DEZENA = 10) 
    | 90 + 10 = 100 (SÍMBOLO = C) -> Válido
    ↳ Sequência: o símbolo da casa decimal *atual* (X) e logo após o mais válido (C)
    | XC é como se fosse, 10 - 100 = -90 mas positivo.

Guarda o símbolo que conseguir em cada etapa.

<b>4. Remover do número total a MAIOR PARTE nesse caso:</b>
2424 - 2000 = 424 e aplicar novamente o mesmo algoritmo no que restou.
