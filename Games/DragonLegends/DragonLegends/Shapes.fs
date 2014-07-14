module Shapes
[<Measure>] type X
[<Measure>] type Y
type Shape =
    | Rectangle of int<X>*int<Y>
    | Circle of int
let Rectangle (x:int<X>) (y:int<Y>) =
    match (x,y) with
    | (x,y) when x>0<X> && y>0<Y> -> Some(Rectangle(x,y))
    | _ -> None
type DrawableShape = {Shape:Shape;Color:System.Drawing.Color; TopLeft:(int<X>*int<Y>)} // consider brush instead of color