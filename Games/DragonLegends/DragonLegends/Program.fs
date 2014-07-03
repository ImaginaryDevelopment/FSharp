// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open System

[<EntryPoint>]
let main argv = 
    
    printfn "%A" argv
    let x = 30
    let y = 25
    let objects = 2
    let seed = 1
    let rect1 = LandGenerator.GenerateMass 0 
    WinForm.RunWinForm()
    let quit = Console.ReadLine()
    0 // return an integer exit code
