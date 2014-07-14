// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open System

open Shapes

[<EntryPoint>]
let main argv = 
    
    printfn "%A" argv
    let x = 30<X>
    let y = 25<Y>
    let objects = 2
    let seed = 1
    let mass = LandGenerator.GenerateMass 0<X> x 0<Y> y seed
    let rect1 = Shape.Rectangle(mass.Width,mass.Height)
    printfn "%A" rect1
    let drawableRect1 = {Shape=rect1;Color=System.Drawing.Color.Black;TopLeft=(mass.Left,mass.Top)}
    WinForm.RunWinForm([drawableRect1])
    let quit = Console.ReadLine()
    0 // return an integer exit code
