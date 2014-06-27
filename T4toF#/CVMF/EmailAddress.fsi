// EmailAddress.fsi
module EmailAddress  

// encapsulated type
type _T

// wrap
val create : string -> _T option
    
// unwrap
val value : _T -> string
