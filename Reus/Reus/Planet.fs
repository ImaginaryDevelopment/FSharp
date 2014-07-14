module Planet
    
    type Occupant = { Wealth:int; Tech:int; Food:int; Natura:int;}
    type Aspect = Occupant
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
    let Surface = 
        Wasteland(IsWet(false))

    type Giant = {
        BrushSize:int
        SideEffectBrushSize:int option // each direction
        Brush:Element
        Ambassadors: Element list }
    
    let OceanGiant = {BrushSize=9;SideEffectBrushSize=Some(13); Brush=Ocean;Ambassadors=List.empty}
    let ForestGiant = {BrushSize=13;SideEffectBrushSize=None; Brush=Forest;Ambassadors=List.empty}
    let MountainGiant = {BrushSize=5;SideEffectBrushSize=Some(14);Brush=Mountain;Ambassadors=List.empty}
    let SwampGiant = {BrushSize=13;SideEffectBrushSize=None; Brush=Swamp;Ambassadors=List.empty}

    type Fertility =
        |None=0
        |Fertile=1
        |GreaterFertility=2

    type Inhabitant =
        | Mineral of Occupant * Aspect list
        | Plant of Occupant* Aspect list
        | Animal of Occupant* Aspect list
        | Settlement of Occupant* Aspect list
        | Project of Occupant* Aspect list

    type Patch = {Surface:Surface;Fertility:Fertility;Inhabitant:Inhabitant option}
//    (surface,fertility,inhabitant) = 
//        member x.Surface=surface
//        member x.Fertility=fertility
    let Patch previousPatch elementBrush =
        let surface = paintSurface previousPatch.Surface elementBrush
        match (surface,previousPatch.Inhabitant) with
        | _,_ when surface = previousPatch.Surface -> previousPatch
        | _,None -> {previousPatch with Surface=surface }
        | Element Ocean,Some(Inhabitant.Mineral _) -> {previousPatch with Inhabitant=None}

        //| _ -> previousPatch
    type Planet ={Patches:Patch list}
    