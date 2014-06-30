// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open Imperial
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let x = 1.0<Imperial.mile>
    let y = x * Imperial.metersPerMile
    let z = Imperial.convertMetersToMiles y
    printfn "%+A -> %+A -> %+A" x y z
    System.Console.ReadLine() |> ignore
    0 // return an integer exit code
