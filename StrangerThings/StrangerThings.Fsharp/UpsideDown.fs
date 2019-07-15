module UpsideDown

type UpsideDown<'a> = {
    value: 'a
}

let portalTo normalValue = 
    { value = normalValue }

let portalFrom upsideDownValue =
    upsideDownValue.value

let apply upsideDownFunc upsideDownValue =
    let normalFunc = upsideDownFunc |> portalFrom

    upsideDownValue
    |> portalFrom
    |> normalFunc
    |> portalTo

let (<*>) = apply

let map1 normalFunction upsideDownValue =
    upsideDownValue
    |> portalFrom
    |> normalFunction
    |> portalTo

let map normalFunction upsideDownValue =            
    (normalFunction |> portalTo) 
    <*> upsideDownValue

let (<!>) = map