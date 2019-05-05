module ``Meus testes do Git``

open NUnit.Framework
open FsUnit
open Dominio

let criarRepositorioFalso() =
    [| 
        {Linguagem = Some "F#"; Forks = 3; Estrelas = 2; IssuesAbertas = 1;}
        {Linguagem = Some "F#"; Forks = 2; Estrelas = 6; IssuesAbertas = 4;}
        {Linguagem = Some "C#"; Forks = 1; Estrelas = 10; IssuesAbertas = 2;}
    |]

[<Test>]
let ``Teste para cálculo de Forks por linguagem``() =
    let calcularComRepositorioMock = 
        criarRepositorioFalso 
        >> calcularForksPorLinguagem 

    let resultado = calcularComRepositorioMock()
    
    resultado.[0]
    |> should equal (Some "F#", 5)
    
[<Test>]
let ``Teste para cálculo de Estrelas por linguagem``() =
    let calcularComRepositorioMock = 
        criarRepositorioFalso 
        >> calcularEstrelasPorLinguagem 

    let resultado = calcularComRepositorioMock()
    
    resultado.[0]
    |> should equal (Some "F#", 8)

[<Test>]
let ``Teste para cálculo de Issues por linguagem``() =
    let calcularComRepositorioMock = 
        criarRepositorioFalso 
        >> calcularIssuesAbertasPorLinguagem 

    let resultado = calcularComRepositorioMock()
    
    resultado.[1]
    |> should equal (Some "C#", 2)