module Patches
open Occupants
open Animals
open Minerals
open Inhabitants

type PatchRec = 
    {Surface:Surface;Fertility:Fertility;Inhabitant:Inhabitant option}
    member x.ToTuple() = (x.Surface,x.Fertility,x.Inhabitant)
    member x.Validate() = 
        match x.ToTuple() with  // does not account for placing fish on land or vice versa
        | _,_,None -> true
        | Element(Ocean),_,Some(Inhabitant.Animal(Animal.Fish(_),_,_)) -> true
        | Element(Ocean),_,Some(_) -> false // only animals in water
        | Element(Forest),_,_ -> true
        | Element(Swamp),_,_ -> true
        | Element(Mountain),_,_ -> true
    
type Patch (patchRec:PatchRec) =
    do if not Patch.Validate PatchRec then failwith "Invalid patch"
    static member Validate (x:PatchRec) = 
        
type Planet = {Patches:Patch list}    
    

//    (surface,fertility,inhabitant) = 
//        member x.Surface=surface
//        member x.Fertility=fertility
let emptyPatch = {Surface=Surface();Fertility = Fertility.None;Inhabitant= None}

let Patch previousPatch elementBrush =
    let surface = paintSurface previousPatch.Surface elementBrush
    match (surface,previousPatch.Inhabitant) with
    | _,_ when surface = previousPatch.Surface -> previousPatch
    | _,None -> {previousPatch with Surface=surface }
    | Element Ocean,Some(Inhabitant.Mineral _) -> {previousPatch with Inhabitant=None}

        //| _ -> previousPatch
