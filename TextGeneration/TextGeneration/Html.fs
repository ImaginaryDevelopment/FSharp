module Html
type Attribute = 
    |Attribute of string
    member x.Value = match x with | Attribute(y) -> y

type Tag = 
    |SelfClosed of string * Attribute list option
    |EmptyTag of string * Attribute list option 
    |ContentTag of string*string * Attribute list option
    override t.ToString() =
        let attrsMap attrs =
            match attrs with 
            |Some(attrs) when attrs <> [] -> 
                let unwrapped = List.map (fun (attr:Attribute) -> attr.Value) attrs
                List.Cons (" ", unwrapped) |> List.reduce (fun x y -> " "+x + " "+y)
            |_ -> System.String.Empty
        let notSelfClosed name attrs content = sprintf "<%s%s>%s</%s>" name (attrsMap attrs) content name
        match t with
        | SelfClosed(name,attrs) -> sprintf "<%s%s/>" name (attrsMap attrs)
        | EmptyTag(name,attrs) -> notSelfClosed name attrs System.String.Empty
        | ContentTag(name,content, attrs) -> notSelfClosed name attrs content
//let private selfClosedTag name = sprintf "<%s/>" name
//let private tagConstructor construction (name:string) attrs =
//        match (name,attrs) with
//        |(name,None) when name<>null && name.Length > 0 -> Some(construction(name,None))
//        |(name,Some(attribs:Attribute list)) when name <> null && name.Length>0 && attribs <> [] -> Some(construction(name,Some(attribs)))
//        | _ -> None
let SelfClosed = 
    function
    | (name:string, None) when name<>null && name.Length > 0 -> Some(Tag.SelfClosed(name,None))
    | (name:string, Some(attribs:Attribute list)) when name<> null && name.Length>0 && attribs<> [] -> Some(SelfClosed(name,Some(attribs)))
    | _ -> None
let EmptyTag =
    function 
    | (name:string, None) when name<> null && name.Length > 0 -> Some(Tag.EmptyTag(name,None))
    | (name:string, Some(attribs:Attribute list)) when name<> null && name.Length>0 && attribs<> [] -> Some(EmptyTag(name,Some(attribs)))
    | _ -> None
let contentTag name content = sprintf "<%s>%s</%s>" name content name
let emptyTag name= contentTag name System.String.Empty
let heading n = sprintf "h%d" n |> contentTag
let para = contentTag "p"
printfn "%s" <| heading 1 """Creating DSLs with F#"""
