module Giants
open Occupants

type Giant = {
    BrushSize:int
    SideEffectBrushSize:int option // each direction
    Brush:Element
    Ambassadors: Element list }
    
let OceanGiant = {BrushSize=9;SideEffectBrushSize=Some(13); Brush=Ocean;Ambassadors=List.empty}
let ForestGiant = {BrushSize=13;SideEffectBrushSize=None; Brush=Forest;Ambassadors=List.empty}
let MountainGiant = {BrushSize=5;SideEffectBrushSize=Some(14);Brush=Mountain;Ambassadors=List.empty}
let SwampGiant = {BrushSize=13;SideEffectBrushSize=None; Brush=Swamp;Ambassadors=List.empty}
