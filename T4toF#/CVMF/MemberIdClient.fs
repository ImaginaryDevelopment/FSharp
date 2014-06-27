module MemberIdClient
open System
open MemberId

let address1 = MemberId -1
let address2 = MemberGuid Guid.Empty

let unwrapped1 = 
  match address1 with
  | Some(MemberId x) -> ()
  | _ -> ()

  
let a = MemberId 1
let b = MemberGuid (Guid.NewGuid())
let c = MemberId -1
let d = MemberId -5
// but you can still pattern match
let printValue = function
| Some (MemberId   x) -> sprintf "case 1, value is %A" x
| Some (MemberGuid x) -> sprintf "case 2, value is %A" x
| None                -> "No value"

let ra = printValue a  // "case 1, value is 1"
let rb = printValue b  // "case 2, value is 67b36c20-2..."
let rc = printValue c  // "No value"