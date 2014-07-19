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

    // stocks
    let symbol = "MSFT"
    
    let nflx = HelloTypeProviders.HelloCsvProvider.Stocks.StockData symbol
    
    let pie = Chart.Pie([("Apples",1);("Oranges",2);("Bananas",3)])
    pie.ShowChart()
    
  
    //let current = nflx.Rows |> Seq.head
    
   
    // keep console open
    System.Console.ReadLine()
    0 // return an integer exit code