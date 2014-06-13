// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "MemberId.fs"

open MemberId

// Define your library scripting code here
let x = MemberId.create(1)
match x with
    | MemberId.MemberId(i) -> printfn "hello int! %i" x
    | MemberId(guid) -> printfn "hello guid! %A" x
