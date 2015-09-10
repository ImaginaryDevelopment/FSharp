namespace Pm.UI.ViewModel
open System
open System.Collections.Generic
type IcdConverterViewModel( icd9To10Codes:IDictionary<string,string>) = 
    member x.Foo = icd9To10Codes
    

