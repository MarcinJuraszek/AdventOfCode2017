open System;

let spiralMemory (location: int) =
    let sqrtFloor = location |> float |> Math.Sqrt |> Math.Floor |> int
    let sqrtFloorOdd = if sqrtFloor % 2 = 1 then sqrtFloor else sqrtFloor - 1
    let depth = ((sqrtFloorOdd - 1) / 2) + 1
    let sqrtFloorOddSquare = Math.Pow(float sqrtFloorOdd, 2.) |> int
    depth + (location - sqrtFloorOddSquare) % depth
