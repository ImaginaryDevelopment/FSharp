namespace UnitTestProject1

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

open Swensen.Unquote
[<TestClass>]
type UnitTest() = 
    [<TestMethod>]
    member x.TestMethod1 () = 
        let testVal = 1
        Assert.AreEqual(1, testVal)
    [<TestMethod>]
    member x.TryUnquote () =
        let ``When 2 is added to 2 expect 4``() = 
            test <@ 2 + 2 = 4 @>
        ``When 2 is added to 2 expect 4``()