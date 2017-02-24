// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open System

let cheatFlatten list =
    let chars = list.ToString()
    let chars = chars.Replace(")","")
    let chars = chars.Replace("(","")
    let chars = chars.Substring(1,chars.Length-2)
    let chars = chars.Replace("[","")
    let chars = chars.Replace("]","")
    let chars = chars.Replace(",","")
    let chars = chars.Replace (" ", "")
    let accum = []
    let chars = chars.ToCharArray() |> List.ofArray
    
    let rec BuildFlattened list accum =
        match list with 
        | head::tail -> BuildFlattened (tail)  (Int32.Parse(head.ToString())::accum)
        | [] -> List.rev accum
    let newList = BuildFlattened chars accum
    newList




[<EntryPoint>]
let main argv = 
    let toBeFlattened = [1,[2,3], [4, [5,6]]]
    System.Console.WriteLine (toBeFlattened.ToString())
    Console.WriteLine(cheatFlatten toBeFlattened)
    System.Console.ReadLine()  |> ignore
    printfn "%A" argv
    0 // return an integer exit code


