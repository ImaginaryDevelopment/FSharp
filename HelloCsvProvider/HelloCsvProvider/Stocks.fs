module HelloTypeProviders.HelloCsvProvider.Stocks
// https://github.com/ImaginaryDevelopment/FSharp/blob/master/FPractice/FPractice/packages.config
// http://fsharp.github.io/FSharp.Data/library/CsvProvider.html
let private url = "http://www.google.com/finance/historical?output=csv&q="
type StockProvider =
  FSharp.Data.CsvProvider<"http://www.google.com/finance/historical?output=csv&q=MSFT",HasHeaders=true, InferRows=10, IgnoreErrors=true>
let StockData symbol = StockProvider.Load(sprintf "%s%s" url symbol)



