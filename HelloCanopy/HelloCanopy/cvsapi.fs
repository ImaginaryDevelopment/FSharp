module CvsApi
open canopy
open TestHelper
let test uri = fun _ -> 
    url uri
    exists <| "head"
    exists <| "title"
