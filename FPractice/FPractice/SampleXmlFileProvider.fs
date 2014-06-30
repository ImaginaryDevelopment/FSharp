module SampleXmlFileProvider
open FSharp.Data
let [<Literal>] filename ="Catalog.xml"
type BookCatalog = XmlProvider<filename>
    
let bookCatalog = BookCatalog.Load(filename)

let authorDirect = bookCatalog.Books |> Seq.map (fun b -> b.XElement)
let authorQuery = query {
    for book in bookCatalog.Books do
            select book

}

let queryAuthors = Seq.distinct authorQuery
