namespace DragonLegends.Test

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

open Swensen.Unquote

open Shapes
[<TestClass>]
type ShapesTests() = 
    [<TestMethod>]
    member x.``Assert Rectangle has measures``() =
        let result = 2 + 1
        result =? 4