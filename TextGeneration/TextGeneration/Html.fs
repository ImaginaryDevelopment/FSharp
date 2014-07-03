module Html
open FExtensions
// does not account for attribute encoding, do not want to take on the dependency to System.Net
type AttributeVal = {Name:string;Value:string}
type Attribute = 
    |Attribute of AttributeVal
    member x.Record = match x with | Attribute(y) -> y
    member x.Key = x.Record.Name
    member x.Value = x.Record.Value

let attribPairs (pairs:(string*string) list) =pairs |>  List.map (fun (k,v)-> Attribute({Name=k;Value=v}))

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
                |> List.map (fun attrRec ->sprintf "%s=\"%s\"" attrRec.Name attrRec.Value)
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
let scriptSrc = EmptyTag "script"
let scriptContent = ContentTag "script"
let body = ContentTag "body"
let head = ContentTag "head" // account for title being a required element?
let title = ContentTag "title"
let link = SelfClosed "link" // in html not closed, in xhtml self-closed
let styleSheetLink href = link (Some(attribPairs [("href",href);("rel","stylesheet");("type","text/css")]))
let private htmlList tag attrs (listItems:Tag list) = 
    let listRendered = listItems |> List.map (fun x->x.ToString()) |> List.reduce (fun x y -> x+y)
    ContentTag tag attrs listRendered

let ul = htmlList "ul"
let ol = htmlList "ol"
//    let listRendered = listItems |> List.map (fun x->x.ToString()) |> List.reduce (fun x y -> x+y)
//    ContentTag "ul" attrs listRendered

#if DEBUG
let Assert expected actualOption = 
    match actualOption with
    |Some(x) -> match x.ToString() with
                |actual when actual = expected -> ()
                |actual -> printfn "expected %s to be %s" actual expected
    | None -> failwith "Actual did not make it through constructor"

let Tests () = 
    let scriptSrcTest () =
        let src = "http://www.google.com"
        let expected = sprintf "<script src=\"%s\"></script>" src
        let testScriptSrc = scriptSrc (Some([Attribute({Name="src";Value=src})]))
        Assert expected testScriptSrc

    let scriptTest () =
        let content = "Console.log('hi');"
        let expected = sprintf "<script>%s</script>" content
        let testScript = scriptContent None content
        Assert expected testScript

    let headingTest () =
        let content = """Creating DSLs with F#"""
        let testHeading = heading 1 None content
        let expected = "<h1>"+content+"</h1>"
        Assert expected testHeading
        
    headingTest()
    scriptTest()
    scriptSrcTest()
#endif