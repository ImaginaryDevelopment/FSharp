// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open Occupant
open Patch
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let surface = Patch.emptyPatch
    
    let patch = {surface with Inhabitant=None}
    0 // return an integer exit code
    