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
let inline GenerateLine<[<Measure>]'T> (rnd:System.Random, min:int< 'T >, max:int<_>) : (int<'T> * int<'T>) =
    let inline _measure i = LanguagePrimitives.Int32WithMeasure(i)
    let inline nextRnd l u =_measure (rnd.Next(int(l),(int(u)+1)))
    let inline mini x y = _measure (Math.Min(int(x),int(y)))
    let inline maxi x y = _measure (Math.Max(int(x),int(y)))

    let v1 = nextRnd min max
    //let vTest = LanguagePrimitives.Int32WithMeasure(rnd.Next(int(min),int(max)+1))
    let vDir = if v1 - min > max-v1 then -1 else 1 // it is farther to which wall?
    let v2 =nextRnd (if vDir= -1 then min else v1) (if vDir = -1 then v1 else max)
    (mini v1 v2,maxi v1 v2)

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