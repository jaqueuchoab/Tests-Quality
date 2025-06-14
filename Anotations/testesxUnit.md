### Testes Unitários com xUnit

1. Terminal com a pasta do projeto aberto
`cd MeuProjeto`

2. Criar um <i>solution</i> um nível acima
`cd ..`
`dotnet new sln -n MinhaSolucao`

> Solution (.sln) em .NET é como uma pasta organizadora de projetos. Serve para gerenciar e agrupar múltipos projetos que estão relacionados entre si.

> Ajuda que o editor de código entenda qual a estrutura geral do projeto, para que builds possam acontecer e que o programa possa ser rodado sem interferência e de forma conjunta

3. Adicionar o projeto à solução
`dotnet sln MinhaSolucao.sln add MeuProjeto/MeuProjeto.csproj`

4. Criar projeto de testes com xUnit
`dotnet new xunit -n MeuProjeto.Tests`

5. Adicionar o projeto de testes à solução 
`dotnet sln MinhaSolucao.sln add MeuProjeto.Tests/MeuProjeto.Tests.csproj`

6. Adicionar uma referência ao projeto principal no projeto de testes
`dotnet add MeuProjeto.Tests/MeuProjeto.Tests.csproj reference MeuProjeto/MeuProjeto.csproj`

Ao fim, com essa configuração será possível criar os testes.
Basta `dotnet test`