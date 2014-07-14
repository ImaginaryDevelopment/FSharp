// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    printfn "%s is %i" HelloTypeProviders.HelloJsonProvider.simple.Name HelloTypeProviders.HelloJsonProvider.simple.Age
    let symbol = "MSFT"
    let nflx = HelloTypeProviders.HelloCsvProvider.Stocks.StockData symbol
    let current = nflx.Rows |> Seq.head
    printfn "%s is %A as of %A" symbol current.Close current.Date

    let realms = HelloTypeProviders.WarcraftJson.realmStatus ()
    let mapped = realms.Realms |> Seq.map (fun r -> r.Name) |> Seq.toList
    let maslowRexxar = HelloTypeProviders.WarcraftJson.characterProvider "Rexxar" "Maslow"
    printfn "realms: %A" mapped
    printfn "characterInfo for %s in %s %A" maslowRexxar.Name maslowRexxar.Realm maslowRexxar
    System.Console.ReadLine()
    0 // return an integer exit code
