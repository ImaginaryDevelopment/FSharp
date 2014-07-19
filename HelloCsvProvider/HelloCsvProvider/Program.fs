// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
// sql ado provider http://fsprojects.github.io/FSharp.Data.SqlClient/
// charting http://fsharp.github.io/FSharp.Data/library/CsvProvider.html

open System.Windows.Forms 
open System.Drawing
open FSharp.Data
open FSharp.Charting
open System
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    
    
    Chart.Line([ for x in 0 .. 10 -> x, x*x ]).ShowChart()
    
  
    //let current = nflx.Rows |> Seq.head
    use form = new Form(Width=400, Height=300, Visible=true, Text="Hello charting")
    Chart.Line([for x in 0 ..10 -> x, x+x]).ShowChart()
    System.Windows.Forms.Application.Run(form)
    // keep console open
    0 // return an integer exit code
