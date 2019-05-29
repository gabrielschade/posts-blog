namespace FunctionApp1

open System
open Microsoft.Azure.WebJobs
open Microsoft.Azure.WebJobs.Host
open Microsoft.Azure.WebJobs.Extensions.Http
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Logging;
open System.IO
open Newtonsoft.Json
open Microsoft.AspNetCore.Mvc
open FSharp.Data

module Function1 =

    [<FunctionName("Function1FSharp")>]
    let DefaultRun ([<HttpTrigger(AuthorizationLevel.Function, "get", Route = null)>] request: HttpRequest ) 
            (log: ILogger) =
        log.LogInformation "F# HTTP trigger function processed a request."
        let name = if request.Query.ContainsKey "name"
                   then request.Query.["name"].ToString() |> Some
                   else None

        match name with
        | Some name -> OkObjectResult (sprintf "Hello, %s" name) :> IActionResult
        | None -> BadRequestObjectResult "Please pass a name on the query string or in the request body" :> IActionResult
        
    [<Literal>]
    let url = "https://en.wikipedia.org/wiki/List_of_Marvel_Cinematic_Universe_films"
    type MarvelCinematicPage = HtmlProvider<url>
       
    type Film = { 
        Name:string; 
        Critical: string
    }

    [<FunctionName("FunctionTypeProviderFSharp")>]
    let Run ([<HttpTrigger(AuthorizationLevel.Function, "get", Route = null)>] request: HttpRequest ) 
            (log: ILogger) =
        let page = MarvelCinematicPage.Load url

        page.Tables.``Critical response``.Rows
        |> Seq.filter( fun data -> data.Film <> "Average")
        |> Seq.map (fun data -> {Name = data.Film; Critical = data.``Rotten Tomatoes``})
        |> OkObjectResult