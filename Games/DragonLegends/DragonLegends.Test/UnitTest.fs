namespace UnitTestProject1

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

open Swensen.Unquote
[<TestClass>]
type UnitTest() = 
    [<TestMethod>]
    member x.RunMsTest () = 
        let testVal = 1
        Assert.AreEqual(1, testVal)
    [<TestMethod>]
    member x.TryUnquote () =
        let ``When 2 is added to 2 expect 4``() = 
            test <@ 2 + 2 = 4 @>
        ``When 2 is added to 2 expect 4``()
    [<TestMethod>]
    member x.TryMoreUnquote () =
        let ``2 + 2 is 4``() = 
            let result = 2 + 2
            result =? 4
        ``2 + 2 is 4``()