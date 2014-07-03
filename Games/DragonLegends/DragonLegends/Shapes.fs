module Shapes
[<Measure>] type X
[<Measure>] type Y
type Shape =
    | Rectangle of int<X>*int<Y>
    | Circle of int
type DrawableShape = {Shape:Shape;Color:System.Drawing.Color} // consider brush instead of color