open System
open Dominio

let imprimir propriedade dados=
    dados
    |> Array.map (fun (linguagem, contador) -> 
        sprintf "Linguagem: %s | %s: %i" 
            (   match linguagem with 
                | Some linguagem' -> linguagem' 
                | None -> "Indisponível"
            ) 
            propriedade 
            contador
    )
    |> Array.iter (Console.WriteLine)

[<EntryPoint>]
let main argv =
    calcularForksPorLinguagemEmRepositoriosGit()
    |> imprimir "Forks"

    calcularIssuesAbertasPorLinguagemEmRepositoriosGit()
    |> imprimir "Issues"

    calcularEstrelasPorLinguagemEmRepositoriosGit()
    |> imprimir "Estrelas"

    Console.ReadKey() |> ignore
    0 
