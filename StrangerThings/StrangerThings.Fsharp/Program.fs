// Learn more about F# at http://fsharp.org

open System
open UpsideDown

[<EntryPoint>]
let main argv =
    
    // ## Return Function
    //let value10 = UpsideDown.portalTo 10
    
    //let valueToString = 
    //    UpsideDown.portalTo (fun object -> object.ToString())

    // ## Without Apply
    //let messageWithLights message = 
    //    printf "%s" message
    //    message
    
    //let upsideDownMessage =
    //    messageWithLights
    //    |> UpsideDown.portalTo
    
    //let result = messageWithLights "A" //Write "A" and Return "A"
    //let resultAtUpsideDown = upsideDownMessage "A" //Compile Error

    // ## With Apply
    //let messageWithLights message = 
    //    printf "%s" message
    //    message

    //let result = messageWithLights "A"

    //let upsideDownMessage =
    //    messageWithLights
    //    |> UpsideDown.portalTo

    //let upsideDownLetter = "A" |> UpsideDown.portalTo

    //let resultAtUpsideDown = 
    //    upsideDownLetter
    //    |> UpsideDown.apply upsideDownMessage 

    //let resultWithOperator = upsideDownMessage <*> upsideDownLetter

    // ## Apply With Multiples Parameters
    //let messagesWithLights message1 message2 = 
    //    printf "%s %s" message1 message2
    //    sprintf "%s %s" message1 message2

    //let upsideDownMessages = 
    //    messagesWithLights 
    //    |> UpsideDown.portalTo

    //let upsideDownLetter = "H" |> UpsideDown.portalTo
    //let upsideDownLetter2 = "I" |> UpsideDown.portalTo

    //let result = upsideDownMessages <*> upsideDownLetter <*> upsideDownLetter2

    //let result2 = 
    //    upsideDownMessages 
    //    <*> ("H" |> UpsideDown.portalTo) 
    //    <*> ("I" |> UpsideDown.portalTo)

    let elevenPower = 100 |> UpsideDown.portalTo
    let elevenIncreasedPower = 
        elevenPower
        |> UpsideDown.map (fun power -> power * 10)

    let elevenIncreasedPower2 elevenPower =
        (fun power -> power * 10) <!> elevenPower
    0 
