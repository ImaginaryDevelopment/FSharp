// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open FSharp.Data
open FSharp.Data.JsonExtensions
open HelloTypeProviders.HelloJsonProvider

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    // simple json
    printfn "%s is %i" simple.Name simple.Age
    
    // stocks
    let symbol = "MSFT"
    let nflx = HelloTypeProviders.HelloCsvProvider.Stocks.StockData symbol
    let current = nflx.Rows |> Seq.head
    
    printfn "%s is %A as of %A" symbol current.Close current.Date
    printfn "%A" nflx.Rows
    // realms
    let realms = HelloTypeProviders.WarcraftJson.realmStatus ()
    let mapped = realms.Realms |> Seq.map (fun r -> r.Name) |> Seq.toList
    printfn "realms: %A" mapped
    //    for i in HelloCsvProvider.query do
    //        printfn "%A" i

    // characters

    let maslow = HelloTypeProviders.WarcraftJson.characterProvider "Rexxar" "Maslow"
    printfn "characterInfo for %s in %s %A" maslow.Name maslow.Realm maslow

    // pets
    let maslowPets = HelloTypeProviders.WarcraftJson.petProvider "Rexxar" "Maslow"
    
    printfn "pets for %s on %s" maslowPets.Name maslowPets.Realm

    // printfn "pets for %s on %s pets: %A" maslowPets.Name maslowPets.Realm maslowPets.Pets
    //[ for p in maslowPets.Pets.Collected -> p]
    //let maxNameLength = maslowPets.Pets.Collected |> List.map (fun x -> x.Name.Length) |> List.max
    //|> List.maxBy (fun x->x.Name.Length)
    //|> List.head
        

    for p in maslowPets.Pets.Collected do // http://langref.org/fsharp/numbers
        printfn "%-10s %-10s" p.Name p.CreatureName

    // keep console open
    System.Console.ReadLine()
    0 // return an integer exit code