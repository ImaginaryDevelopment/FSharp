module Imperial
open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

//[<Measure>] type kilometer = meter * 1000
[<Measure>] type inch
[<Measure>] type mile
[<Measure>] type cm

// constants for multiplication

let cmPerMeter = 100.0<cm/meter>
let cmPerInch = 2.54<cm/inch>
let metersPerMile:float<meter/mile> = 1609.34<meter/mile>

//methods for division

let convertCentimetersToInches (x:float<cm>) = x / cmPerInch
let convertMetersToMiles (x:float<meter>) = x / metersPerMile
//[<Measure>]