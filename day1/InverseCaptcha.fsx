let compareWithNextValue (input: (int array)) (index: int) : int  =
    (index + 1) % input.Length

let compareWithValueHalfWayAway (input: (int array)) (index: int) : int  =
    (index + (input.Length / 2)) % input.Length

let inverseCaptcha getIndexToCompare (input: string) =
    let arrayOfDigits = input |> Seq.map (fun c -> (int c) - 48) |> Seq.toArray

    let getValueForPair a b =
        if a = b then b else 0
    
    let rec inverseCaptchaIter (input: int array) (index: int) (acc: int) : int =
        let indexToCompare = getIndexToCompare input index
        let currentValue = input.[index];
        let valueToCompare = input.[indexToCompare]
        let newAcc = acc + (getValueForPair currentValue valueToCompare)

        if input.Length = index + 1 then
            newAcc
        else
            inverseCaptchaIter input (index + 1) newAcc

    inverseCaptchaIter arrayOfDigits 0 0

let inverseCaptchaNextValue = inverseCaptcha compareWithNextValue
let inverseCaptchaValueHalfWayAway = inverseCaptcha compareWithValueHalfWayAway