open System

let passphrases (validation: string[] -> bool) (input: string) =
    let passphrases = input.Split([| "\n"; "\r" |], StringSplitOptions.RemoveEmptyEntries)
    passphrases
    |> Array.where (fun p -> 
        let words = p.Split()
        validation words
    )
    |> Array.length

let countMatchesDistinctCount data =
    let count = data |> Array.length
    let distCount = data |> Array.distinct |> Array.length
    count = distCount

let passphrases1 = passphrases countMatchesDistinctCount

let passphrases2 = passphrases (fun words ->
    let sorted =
        words
        |> Array.map (fun s -> new System.String(s |> Seq.sort |> Seq.toArray))

    countMatchesDistinctCount sorted
)