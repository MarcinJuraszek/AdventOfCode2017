open System;

let corruptionChecksum (input: string) = 
    input.Split([| "\n"; "\r" |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun l -> l.Split(Array.empty<string>, StringSplitOptions.RemoveEmptyEntries) |> Array.map int)
    |> Array.sumBy (fun l -> (Array.max l) - (Array.min l))

let corruptionChecksum2 (input: string) = 
    input.Split([| "\n"; "\r" |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun l -> l.Split(Array.empty<string>, StringSplitOptions.RemoveEmptyEntries) |> Array.map int)
    |> Array.sumBy (fun l ->
         l |> Array.sumBy (fun f ->
            l |> Array.sumBy (fun s -> 
                if f <> s && f > s && f % s = 0 then f / s else 0)))
