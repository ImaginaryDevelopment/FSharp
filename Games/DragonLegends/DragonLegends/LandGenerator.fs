module LandGenerator
open System

open Shapes

let inline FromOne() = LanguagePrimitives.GenericOne

type Direction = 
    |North
    |East
    |South
    |West

// http://davefancher.com/2012/11/18/f-more-on-units-of-measure/
let inline GenerateLine<'T> (rnd:System.Random, min:int<_>, max:int<_>) : (int<_> * int<_>) =
    let one = max * 0<_> + 1<_>
    let v1:int< ^a > = rnd.Next(int(min),int(max)+1) * 1<_>
    let vDir = if v1 - min > max-v1 then -1 else 1 // it is farther to which wall?
    let v2 = rnd.Next((if vDir= -1 then min else v1),(if vDir = -1 then v1+1 else max+1))
    (1<_>*Math.Min(v1,v2),Math.Max(v1,v2))

let GenerateMass (xMin:int<X>) (xMax:int<X>) yMin yMax seed = 
    let rnd = Random(seed)
    let xLine = GenerateLine (rnd, xMin, xMax) 
    let yLine = GenerateLine rnd yMin yMax
    let x=rnd.Next(int(xMin),int(xMax)+1)*1<X>
    let y=rnd.Next(yMin,yMax+1)
    let xDir = if x-xMin > xMax-x then -1 else 1 // it is farther to which wall?
    let x2 = rnd.Next((if xDir= -1 then xMin else x), (if xDir= -1 then x+1 else xMax+1 ))
    let xVal = (Math.Min(x,x2), Math.Max(x,x2))
    0