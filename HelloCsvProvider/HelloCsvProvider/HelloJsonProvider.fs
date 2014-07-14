module HelloTypeProviders.HelloJsonProvider
open FSharp.Data
type Simple = JsonProvider<""" { "name":"John", "age":94} """>
let simple = Simple.Parse(""" { "name":"Tomas","age":4 } """)

