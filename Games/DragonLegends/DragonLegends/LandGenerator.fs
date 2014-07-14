module LandGenerator
open System

open Shapes


type Direction = 
    |North
    |East
    |South
    |West

// http://davefancher.com/2012/11/18/f-more-on-units-of-measure/
let GenerateLine (rnd:System.Random) (min:int<_>) (max:int<_>) =
    let ``measure`` i = LanguagePrimitives.Int32WithMeasure(i)
    let inline nextRnd l u =``measure`` (rnd.Next(int(l),(int(u)+1))) // lower bound and upper inclusive bound
    let inline mini a b = ``measure`` <| Math.Min(int(a), int(b))
    let inline maxi a b = ``measure`` (Math.Max(int(a),int(b)))

    let v1 = nextRnd min max
    
    let vDir = if v1 - min > max-v1 then -1 else 1 // it is farther to which wall?
    let v2 =nextRnd (if vDir= -1 then min else v1) (if vDir = -1 then v1 else max)
    (mini v1 v2,maxi v1 v2)

type Rectangle2D(left:int<X>,right:int<X>,top:int<Y>,bottom:int<Y>) =
    do 
        if left>right then failwith "left>right"
        if bottom>top then failwith "bottom>top"
    member x.Left = left
    member x.Right = right
    member y.Top = top
    member y.Bottom = bottom
    member x.Width = left-right
    member y.Height = top-bottom

let GenerateMass (xMin:int<X>) (xMax:int<X>) (yMin:int<Y>) (yMax:int<Y>) seed = 
    if(xMin>xMax) then
        failwith "xMin>xMax"
    if(yMin>yMax) then
        failwith "yMin>yMax"
    let rnd = Random(seed)
    let (x1,x2) = GenerateLine rnd xMin xMax
    if(x1<xMin) then failwith "x1<xMin"
    if(x2<x1) then failwith "x2<x1"
    if(xMax<x2) then failwith "xMax<x2"

    let (y1,y2) = GenerateLine rnd yMin yMax
    Rectangle2D(x1,x2,y1,y2) //enough information to make a rectangle x1..x2 and y1..y2