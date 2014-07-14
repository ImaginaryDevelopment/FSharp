module Inhabitants
open Occupants
open Animals
    type Inhabitant =
        | Mineral of Modifier * Aspects list
        | Plant of Modifier* Aspects list
        | Animal of Animal * Modifier * Aspects list
        | Settlement of Modifier
        | Project of Modifier