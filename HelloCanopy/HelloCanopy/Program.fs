//these are similar to C# using statements
open canopy
open runner
open System

let exists selector = 
    let someEle = someElement selector
    match someEle with
    | Some(_) -> true
    | None -> false
//start an instance of the firefox browser
start firefox

//this is how you define a test
"taking canopy for a spin" &&& fun _ ->
    //this is an F# function body, it's whitespace enforced

    //go to url
    url "http://lefthandedgoat.github.io/canopy/testpages/"

    //assert that the element with an id of 'welcome' has
    //the text 'Welcome'
    "#welcome" == "Welcome"

    //assert that the element with an id of 'firstName' has the value 'John'
    "#firstName" == "John"

    //change the value of element with
    //an id of 'firstName' to 'Something Else'
    "#firstName" << "Something Else"

    //verify another element's value, click a button,
    //verify the element is updated
    "#button_clicked" == "button not clicked"
    click "#button"
    "#button_clicked" == "button clicked"
 // examples : https://github.com/lefthandedgoat/canopy/blob/master/tests/basictests/Program.fs
"taking cvs for a spin" &&& fun _ ->
    url "http://www.clearvoicesurveys.com/"
    true === (someElement "[id$='txtLogin']").IsSome
//run all tests
run()

printfn "press [enter] to exit"
System.Console.ReadLine() |> ignore

quit()