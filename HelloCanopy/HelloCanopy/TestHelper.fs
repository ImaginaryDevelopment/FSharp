module TestHelper
open System.Text.RegularExpressions

open canopy

type HtmlAttribute private (input) =
    let attr = input
    
    static member Create(input) =  
        match input with
        | invalid when Regex.IsMatch(invalid,"""([^\t\n\f \/>"'=]+)""")=false -> None // failwithf "invalid attribute %s" input
        | dash when dash.Contains("-") -> Some(HtmlAttribute(sprintf "'%s'" input))
        | a when a<> null -> Some(HtmlAttribute(input))
        | _ -> None // failwithf "invalid attribute %s" input
    member x.StartsWith selector =
        sprintf "[%s^='%s']" attr selector
    member x.EndsWith selector =
        sprintf "[%s$='%s']" attr selector

let exists selector = 
    true === (someElement selector).IsSome

let idAttr = HtmlAttribute.Create("id").Value
let hrefAttr = HtmlAttribute.Create("href").Value
//let attribute input = 
//    match input with
//    | invalid when Regex.IsMatch(invalid,"""([^\t\n\f \/>"'=]+)""") -> failwithf "invalid attribute %s" input
//    | dash when dash.Contains("-") -> sprintf "'%s'" input
//    | a when a<> null -> input
//    | _ -> failwithf "invalid attribute %s" input
//
//let idStartsWith selector = 
//    attrStartsWith "id" selector
