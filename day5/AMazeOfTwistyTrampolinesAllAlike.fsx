 open System

 let jumps (newIndexFactory: int -> int) (input: string) : int =
    let steps = input.Split([| "\n"; "\r" |], StringSplitOptions.RemoveEmptyEntries) |> Array.map int

    let rec move (steps: int[]) index depth =
        if index >= steps.Length then
            depth
        else
            let newIndex =
                index + steps.[index]
            steps.[index] <- newIndexFactory steps.[index]
            move steps newIndex (depth + 1)

    move steps 0 0

let jumps1 = jumps (fun oldValue -> oldValue + 1)

let jumps2 = jumps (fun oldValue -> oldValue +  if oldValue >= 3 then -1 else 1)