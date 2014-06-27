// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "MemberId.fs"

open MemberId

// Define your library scripting code here

let y = MemberId 5
let z = MemberId -5
match y with
| Some(MemberId x) -> printfn "memberid has some %A %i" y x
| None -> printfn "memberId has none"
| _ -> printfn "default case, y?"


match z with
| Some(MemberId x) -> printfn "memberid has some %A %i" y x
| None -> printfn "memberId has none"
| _ -> printfn "default case, y?"
