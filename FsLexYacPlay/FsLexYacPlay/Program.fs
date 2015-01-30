// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
let x = "
    SELECT x, y, z
    FROM t1
    LEFT JOIN t2
    INNER JOIN t3 ON t3.ID = t2.ID
    WHERE x = 50 AND y = 20
    ORDER BY x ASC, y DESC, z
"

open System
open Sql
open Microsoft.FSharp.Text

let ParseSql sql =
    let lexbuf = Lexing.LexBuffer<_>.FromString sql
    let output = SqlParser.start SqlLexer.tokenize lexbuf
    printfn "parsed as: %A" output
    output

[<EntryPoint>]
let main argv =
    printfn "args:%A" argv
    let parsed = ParseSql x

    Console.WriteLine("(press any key)")
    Console.ReadKey(true) |> ignore
    0 // return an integer exit code

