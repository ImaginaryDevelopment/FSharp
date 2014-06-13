module MemberIdClient
open System
open MemberId

let address1 = MemberId.createId 1
let address2 = MemberId.createGuid <| Guid.Empty
