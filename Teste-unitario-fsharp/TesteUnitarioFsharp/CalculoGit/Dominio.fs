module Dominio
open FSharp.Data

[<Literal>]
let urlRepositorios = "https://api.github.com/users/dotnet/repos"

type Repositorios = JsonProvider<urlRepositorios>

type GitRepositorio = {
    Forks: int
    Linguagem: string option
    IssuesAbertas: int
    Estrelas: int
}

let carregarRepositorios() =
    Repositorios.Load urlRepositorios
    |> Array.map( fun repositorio -> 
        {
            Forks = repositorio.ForksCount
            Linguagem = repositorio.Language
            IssuesAbertas = repositorio.OpenIssuesCount
            Estrelas = repositorio.StargazersCount
        })

let calcularPorLinguagem propriedadeParaCalculo repositorio =
    repositorio
    |> Array.groupBy( fun repositorio -> repositorio.Linguagem)
    |> Array.map( fun (linguagem, repositorio) -> 
        linguagem, 
        (repositorio |> Array.sumBy(propriedadeParaCalculo))
    ) 
    
let calcularForksPorLinguagem repositorio =
    repositorio
    |> calcularPorLinguagem (fun repo -> repo.Forks)

let calcularEstrelasPorLinguagem repositorio =
    repositorio
    |> calcularPorLinguagem (fun repo -> repo.Estrelas)

let calcularIssuesAbertasPorLinguagem repositorio =
    repositorio
    |> calcularPorLinguagem (fun repo -> repo.IssuesAbertas)

let calcularForksPorLinguagemEmRepositoriosGit =
    carregarRepositorios
    >> calcularForksPorLinguagem

let calcularEstrelasPorLinguagemEmRepositoriosGit =
    carregarRepositorios
    >> calcularEstrelasPorLinguagem

let calcularIssuesAbertasPorLinguagemEmRepositoriosGit =
    carregarRepositorios
    >> calcularIssuesAbertasPorLinguagem

        

