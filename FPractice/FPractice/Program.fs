
// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    printfn "%A" SampleXmlProvider.queryAuthors
    printfn "%A" SampleXmlProvider.authorDirect
    let mutable s = System.Console.ReadLine()
    
    printfn "%A" SampleXmlFileProvider.queryAuthors
    printfn "%A" SampleXmlFileProvider.authorDirect
    let s = System.Console.ReadLine()
    printfn "%A" s
    System.Console.ReadLine() |> ignore
    0 // return an integer exit code
