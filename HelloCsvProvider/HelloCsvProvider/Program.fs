﻿// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
// sql ado provider http://fsprojects.github.io/FSharp.Data.SqlClient/
// charting http://fsharp.github.io/FSharp.Data/library/CsvProvider.html

open System.Windows.Forms 
open System
open System.Drawing
open FSharp.Data
open FSharp.Charting

open HelloTypeProviders.HelloCsvProvider.Stocks
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    
    let nflx = StockData "NFLX"
    //let msft = Stock
    let chartForm = (Chart.FastLine [ for row in nflx.Rows -> row.Date, row.Open ]).CreateForm()
    
    System.Windows.Forms.Application.Run(chartForm)
    // keep console open
    0 // return an integer exit code
