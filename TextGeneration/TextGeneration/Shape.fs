module Shape

// which comes first length or width?
// x = 
type Shape = 
    | Circle of float //radius
    //| Ellipse of float*float // width * height? // what rounding are the points? slope/curvature
    | Rectangle of float*float // width * height
    | Square of float 
    with
        member s.Area() = 
            match s with 
            | Circle radius -> System.Math.PI * radius
            | Rectangle( width,height) -> width * height
            | Square width -> width * width


