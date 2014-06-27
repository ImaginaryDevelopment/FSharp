namespace FSharpWeb.Controllers
open System
open System.Collections.Generic
open System.Linq
open System.Net
open System.Net.Http
open System.Net.Http.Headers
open System.Web.Http
open FSharpWeb.Models

/// Retrieves values.
type CarsController() =
    inherit ApiController()

    let values = [| { Make = "Ford"; Model = "Mustang" }; { Make = "Nissan"; Model = "Titan" } |]
    [<Route("cars/html")>]
    [<HttpGet>]
    member x.Html() =
        
        let viewPath = System.Web.HttpContext.Current.Server.MapPath("""~/Views/Cars.cshtml""")

        let template = System.IO.File.ReadAllText(viewPath)
        let rendered = RazorEngine.Razor.Parse(template) // https://github.com/Antaris/RazorEngine
        let response = new HttpResponseMessage(HttpStatusCode.OK)
        response.Content <- new StringContent(rendered)
        response.Content.Headers.ContentType <- new MediaTypeHeaderValue("text/html")
        response
    /// Gets all values.
    member x.Get() = values
