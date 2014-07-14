module Cvs
open canopy
open TestHelper

let test uri = fun _ ->
    url uri
    exists <| idAttr.EndsWith "txtLogin"
    exists <| hrefAttr.StartsWith "Privacy"
    exists <| hrefAttr.StartsWith "Terms"
    exists <| hrefAttr.StartsWith "Contact"
    click <| idAttr.EndsWith "btnLogin"
    exists <| idAttr.EndsWith "lblErrorMessage"