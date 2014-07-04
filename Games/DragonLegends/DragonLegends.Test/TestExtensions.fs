module TestExtensions
open Swensen.Unquote
// http://blog.ploeh.dk/2014/03/21/composed-assertions-with-unquote/
let verify = test
let convertsTo<'a> candidate =
    match box candidate with
    | :? 'a as converted -> Some converted
    | _ -> None