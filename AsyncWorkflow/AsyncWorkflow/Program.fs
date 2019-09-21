// Learn more about F# at http://fsharp.org

open System
open System.Net
open System.IO
open FSharp.Data

[<Literal>]
let githubUrl = "https://api.github.com/users/gabrielschade"
type GitHubProfile = JsonProvider<githubUrl>

let fetchUrl url =
    let request = WebRequest.Create (Uri url)
    use response = request.GetResponse()
    use stream = response.GetResponseStream()
    use reader = new StreamReader( stream)
    let html = reader.ReadToEnd()
    printfn "finished reading %s" url
    html

let asyncFetchUrl url = async{
    let request = WebRequest.Create (Uri url)
    use! response = request.AsyncGetResponse()
    use stream = response.GetResponseStream()
    use reader = new StreamReader( stream)
    let html = reader.ReadToEnd()
    
    printfn "finished reading %s" url
    return html
}

let downloadHtmls() = 
    let sites = [
        "https://www.github.com/"
        "https://www.google.com/"
        "https://www.amazon.com/"
        "https://gabrielschade.github.io/"
    ]
    
    
    
    let stopwatch = new Diagnostics.Stopwatch()
    stopwatch.Start()

    sites
    |> List.map(asyncFetchUrl)
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore

    printfn "Elapsed Time: %i" stopwatch.ElapsedMilliseconds


let print text =
    printfn "%s" text

let functionDoExample() =
    print "Hello World"

let wait seconds = async{
    printfn "before working"
    do! Async.Sleep (seconds * 1000)
    printfn "after working"
}

let printNumberOfRepos userName = async{
    let baseUrl = "https://api.github.com/users/"
    let url = sprintf "%s%s" baseUrl userName
    let! data = GitHubProfile.AsyncLoad url
    printfn "%s Repos: %i" userName data.PublicRepos
}

let getNumberOfRepos userName = async{
    let baseUrl = "https://api.github.com/users/"
    let url = sprintf "%s%s" baseUrl userName
    let! data = GitHubProfile.AsyncLoad url
    return data.PublicRepos
}

let evaluateRepos userName = async {
    let print value =
        printfn "%s: %s" userName value

    match! getNumberOfRepos userName with
    | value when value > 2000 -> print "Fantastic"
    | value when value > 1000 -> print "Huge"
    | value when value > 100 -> print "Great"
    | _ -> print "Meh"
}

let waitAndDo seconds userName = async {
    do! Async.Sleep (seconds * 1000)
    return! getNumberOfRepos userName
}
    

[<EntryPoint>]
let main argv =
    let users = [
        "gabrielschade"
        "google"
        "microsoft"
        "dotnet"
    ]
    printfn "started"
    
    users
    |> List.mapi (fun index user -> waitAndDo index user)
    |> Async.Parallel
    |> Async.RunSynchronously
    |> Array.iter (printfn "%i")
    

    printfn "finished"
    Console.ReadKey() |> ignore
    0
