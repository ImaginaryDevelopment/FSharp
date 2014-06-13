module MemberId
open System
type _T = 
    | Id of int
    | MemberGuid of Guid

let createId id = Some(Id(id))
let createGuid guid = Some(MemberGuid( guid))