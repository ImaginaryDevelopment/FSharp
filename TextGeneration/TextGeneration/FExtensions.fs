module FExtensions
// let private cons head list = List.Cons(head,list)
// http://fsharpforfunandprofit.com/posts/type-extensions/
type List<'T> with
    static member cons x y = List.Cons(x,y)
