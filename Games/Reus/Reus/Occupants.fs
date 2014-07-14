module Occupants
    
type Modifier = { Wealth:int; Tech:int; Food:int; Natura:int;Danger:int}
type Aspect = {Name:string;Modifier:Modifier}

type OceanAspect =
    |Crystal 
    |Growth
    |Herd

type ForestAspect = 
    |Leaf
    |Fruit
    |Hunt

type MountainAspect =
    |Exotic
    |Seismic
    |Noble
    
type Aspects =
    |Forest of ForestAspect
    |Ocean of OceanAspect
    |Mountain of MountainAspect

type Element =
    |Ocean
    |Forest
    |Mountain
    |Swamp

type IsWet = | IsWet of bool

type Surface =
    |Wasteland of IsWet
    |Element of Element

let paintSurface previousSurface elementBrush = 
    match (previousSurface, elementBrush) with
    |Wasteland(IsWet(true)),x -> Element x
    |Wasteland(_),Ocean -> Surface.Element(Ocean)
    |Wasteland(_),Mountain -> Surface.Element Mountain
    |Element Ocean, Mountain -> Wasteland(IsWet(false))
    |Element Forest, Swamp -> Surface.Element Swamp
    |Element Swamp, Forest -> Surface.Element Forest
    |Element Mountain, Ocean -> Wasteland(IsWet(false))
    |x,_ -> x

//shadow Surface constructor
let Surface () = 
    Wasteland(IsWet(false))

type Fertility =
    |None=0
    |Fertile=1
    |GreaterFertility=2



  
    