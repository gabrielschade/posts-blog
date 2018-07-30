open System

[<Measure>] type g //grama
[<Measure>] type kg //quilograma
[<Measure>] type t //tonelada

[<Measure>] type m //metro
[<Measure>] type km //quilometro

[<Measure>] type h //horas
[<Measure>] type s //segundos

[<Measure>] type A //ampere

[<Measure>] type T = kg / (A * s^2) //Tesla

[<Measure>] type v = km/h //velocidade

let distancia = 300<km>
let tempo = 1<h>

let velocidade = distancia/tempo
//let erro = distancia + tempo
//let erro2 = distancia - tempo

let largura = 50<m>
let comprimento = 75<m>

let area = largura * comprimento

let velocidadeComUnidade = 150<v>

let calcularVelocidade (distancia:int<km>) (tempo:int<h>) =
    distancia/tempo


//let velocidadeCalculada = calcularVelocidade 300 4
let velocidadeCalculada = calcularVelocidade 300<km> 4<h>

let metrosPorQuilometros = 1000.0<m/km>
let valorEmMetros = 10.0<km> * metrosPorQuilometros

let quilometrosPorMetros = 0.001<km/m>
let valorEmQuilometros = 3000.0<m> * quilometrosPorMetros

let dobrar (valor:int<'u>) =
    valor * 2

let dobroKm = dobrar 10<km>
let dobroM = dobrar 5<m>
let dobro = dobrar 10

let converter (fatorConversao:float<'u/'v>) (valor:float<'v>) =
    valor * fatorConversao

//let valorCalculado = 
//    converter metrosPorQuilometros 20.0<km>

let valorCalculado = 
    20.0<km>
    |> converter metrosPorQuilometros 

let converterKmParaM = 
    converter metrosPorQuilometros 

let converterMParaKm =
    converter quilometrosPorMetros

let metros = 10.0<km> |> converterKmParaM
let quilometros = 10.0<m> |> converterMParaKm

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    Console.ReadKey() |> ignore
    0
