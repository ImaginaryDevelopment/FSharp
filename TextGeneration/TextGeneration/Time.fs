module Time
open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames
// http://msdn.microsoft.com/en-us/library/vstudio/dd233243(v=vs.100).aspx
[<Measure>]
type hour
[<Measure>]
type minute
// open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames.second
[<Measure>]
type day
[<Measure>]
type month
[<Measure>]
type year

let secondsPerMinute = 60.0<second/minute>
let minutesPerHour = 60.0<minute/hour>
let hoursPerDay = 24.0<hour/day>

let convertMinutesToSeconds x = x * secondsPerMinute
let convertHoursToMinutes x = x * minutesPerHour
let convertDaysToHours x = x * hoursPerDay