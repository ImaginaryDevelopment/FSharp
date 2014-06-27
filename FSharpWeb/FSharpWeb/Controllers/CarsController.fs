namespace FSharpWeb.Controllers
open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http
open System.Web.Razor

open FSharpWeb.Models

/// Retrieves values.
type CarsController() =
    inherit ApiController()

    let mutable values = [| { Make = "Ford"; Model = "Mustang" }; { Make = "Nissan"; Model = "Titan" } |]

    /// Gets all values.
    member x.Get() = values
    member x.Html() =
        let viewPath = System.Web.HttpContext.Current.Server.MapPath("""~/Views/CarsController/Cars.cshtml""")
        let template = System.IO.File.ReadAllText(viewPath)
        //let razorHost = System.Web.WebPages.Razor.WebRazorHostFactory.CreateHostFromConfig(this.VirtualPath);
        let razorHost = RazorEngineHost(CSharpRazorCodeLanguage())
        let parser = System.Web.Razor.Parser.RazorParser( razorHost.DecorateCodeParser(razorHost.CodeLanguage.CreateCodeParser()), razorHost.DecorateMarkupParser(razorHost.CreateMarkupParser()))
        printfn "%A" parser.DesignTimeMode
        use sr = new IO.StringReader(template)
        let parseResults = parser.Parse(sr)
        match parseResults with 
        | pr when pr.ParserErrors.Any() || pr.Success=false -> new HttpResponseMessage(Net.HttpStatusCode.InternalServerError)
        | _ ->
            let razorTemplateEngine = RazorTemplateEngine(razorHost)
            use codeSr = new IO.StringReader(template)
            let generatedCode = razorTemplateEngine.GenerateCode(sr)
            
            let this.Host.DecorateCodeGenerator(this.Host.CodeLanguage.CreateCodeGenerator(className, rootNamespace, sourceFileName, this.Host))
            let razorBuildProvider = RazorBuildProvider()
            let codeGenerator = this.CreateCodeGenerator(className, rootNamespace, sourceFileName);
            let response = new HttpResponseMessage(Net.HttpStatusCode.OK)
            response.Content <- new StringContent(parseResults.Document)
            response
    member x.Put(car) = values <- Array.append values car
