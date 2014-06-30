module Html
open FExtensions

type AttributeVal = {Name:string;Value:string}
type Attribute = 
    |Attribute of AttributeVal
    member x.Record = match x with | Attribute(y) -> y

type Tag = 
    |SelfClosed of string * Attribute list option
    |EmptyTag of string * Attribute list option 
    |ContentTag of string*string * Attribute list option

    override t.ToString() =
        let attrsMap attrs =
            match attrs with 
            |Some(attrs) when attrs <> [] -> 
                attrs
                |> List.map (fun (attr:Attribute) -> attr.Record) 
                |> List.map (fun attrRec ->attrRec.Name+"=\""+attrRec.Value)
                |> List.cons " "
                |> List.reduce (fun x y -> x + " "+y)
            |_ -> System.String.Empty
        let notSelfClosed name attrs content = sprintf "<%s%s>%s</%s>" name (attrsMap attrs) content name
        match t with
        | SelfClosed(name,attrs) -> sprintf "<%s%s/>" name (attrsMap attrs)
        | EmptyTag(name,attrs) -> notSelfClosed name attrs System.String.Empty
        | ContentTag(name,content, attrs) -> notSelfClosed name attrs content

let private tagConstructor construction (name:string) attrs =
        match (name,attrs) with
        |(name,None) when name<>null && name.Length > 0 -> Some(construction(name,None))
        |(name,Some(attribs:Attribute list)) when name <> null && name.Length>0 && attribs <> [] -> Some(construction(name,Some(attribs)))
        | _ -> None

let SelfClosed = tagConstructor SelfClosed
let EmptyTag = tagConstructor EmptyTag
let ContentTag name attrs content= 
    let emptyTag = EmptyTag name attrs
    match emptyTag with 
    | Some(EmptyTag(n,a)) -> Some(ContentTag(n, content, a))
    | _ -> None
    
let heading n = sprintf "h%d" n |> ContentTag
let para = ContentTag "p"
let Tests () = 
    let content = """Creating DSLs with F#"""
    let testHeading = heading 1 None content
    let expected = "<h1>"+content+"</h1>"
    match  testHeading with
    |Some(x) -> match x.ToString() with
                | actual when actual = expected -> ()
                | actual -> printfn "expected %s to be %s" actual expected
    |None -> failwith "Test heading did not generate"