namespace DragonLegends.Test

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

open Swensen.Unquote
open TestExtensions
open Shapes

[<TestClass>]
type ShapesTests() = 
   
    [<TestMethod>]
    member t.``Assert Rectangle has measures``() =
        test <@ Rectangle 1<X> 2<Y> |> Option.isSome @>
    [<TestMethod>]
    member t.``Assert Rectangle rejects 0<X>``() =
        test <@ Rectangle 0<X> 1<_> |> Option.isNone @>
    [<TestMethod>]
    member t.``Assert Rectangle rejects 0<Y>``() =
        test <@ Rectangle 1<X> 0<Y> |> Option.isNone @>
    [<TestMethod>]
    member t.``Assert Rectangle rejects -1<X>``() =
        test <@ Rectangle -1<X> 1<Y> |> Option.isNone @>
    [<TestMethod>]
    member t.``Assert Rectangle rejects -1<Y>``() =
        test <@ Rectangle 1<X> -1<Y> |> Option.isNone @>