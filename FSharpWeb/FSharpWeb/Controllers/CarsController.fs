namespace FSharpWeb.Controllers
open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http
open FSharpWeb.Models

/// Retrieves values.
type CarsController() =
    inherit ApiController()

    let values = [| { Make = "Ford"; Model = "Mustang" }; { Make = "Nissan"; Model = "Titan" } |]
    member x.Html() =
        let viewPath = System.Web.HttpContext.Current.Server.MapPath("""~/Views/CarsController/Cars.cshtml""")
        let template = System.IO.File.ReadAllText(viewPath)
        ""
    /// Gets all values.
    member x.Get() = values
