module ``Testes da Calculadora``

open FsUnit
open TesteUnitarioFsharp
open NUnit.Framework
open NUnit.Framework.Constraints

[<Test>]
let ``Teste somando os valores 2 e 3``() =
    let parcela1 = 2
    let parcela2 = 3

    Calculadora.Somar(parcela1, parcela2)
    |> should equal 5