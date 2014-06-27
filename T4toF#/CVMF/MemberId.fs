module MemberId
open System

type MemberId = 
    | MemberId of int
    | MemberGuid of Guid

// Shadow constructors
let MemberId  x = if x > 0 then Some (MemberId x) else None
let MemberGuid x = Some (MemberGuid x)


