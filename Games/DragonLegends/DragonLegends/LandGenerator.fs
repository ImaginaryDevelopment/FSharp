module LandGenerator
open System
type Direction = 
    |North
    |East
    |South
    |West
let GenerateLine (rnd:System.Random) min max =
    let v1 = rnd.Next(min,max+1)
    let vDir = if v1-min > max-v1 then -1 else 1 // it is farther to which wall?
    let v2 = rnd.Next((if vDir= -1 then min else v1),(if vDir = -1 then v1+1 else max+1))
    (Math.Min(v1,v2),Math.Max(v1,v2))

let GenerateMass xMin xMax yMin yMax seed = 
    let rnd = Random(seed)
    let xLine = GenerateLine rnd xMin xMax
    let yLine = GenerateLine rnd yMin yMax
    let x=rnd.Next(xMin,xMax+1)
    let y=rnd.Next(yMin,yMax+1)
    let xDir = if x-xMin > xMax-x then -1 else 1 // it is farther to which wall?
    let x2 = rnd.Next((if xDir= -1 then xMin else x), (if xDir= -1 then x+1 else xMax+1 ))
    let xVal = (Math.Min(x,x2), Math.Max(x,x2))
    0