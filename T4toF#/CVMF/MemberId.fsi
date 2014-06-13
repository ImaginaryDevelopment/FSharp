module MemberId
open System
type _T

val createId : int -> _T option
val createGuid : Guid -> _T option
