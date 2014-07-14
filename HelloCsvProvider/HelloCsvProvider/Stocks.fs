module HelloTypeProviders.HelloCsvProvider.Stocks
// https://github.com/ImaginaryDevelopment/FSharp/blob/master/FPractice/FPractice/packages.config
// http://fsharp.github.io/FSharp.Data/library/CsvProvider.html
let private url = "http://www.google.com/finance/historical?output=csv&q="
let [<Literal>] sample = """Date,Open,High,Low,Close,Volume
11-Jul-14,41.70,42.09,41.48,42.09,24087374
10-Jul-14,41.37,42.00,41.05,41.68,21856832
9-Jul-14,41.98,41.99,41.53,41.67,18445910
8-Jul-14,41.87,42.00,41.61,41.78,31218208
7-Jul-14,41.75,42.12,41.71,41.99,21953619
3-Jul-14,41.91,41.99,41.56,41.80,15969310
2-Jul-14,41.73,41.90,41.53,41.90,20208526
1-Jul-14,41.86,42.15,41.69,41.87,26922597
30-Jun-14,42.17,42.21,41.70,41.70,30805472
27-Jun-14,41.61,42.29,41.51,42.25,74641945
26-Jun-14,41.93,41.94,41.43,41.72,23604409"""
type StockProvider =
  FSharp.Data.CsvProvider<sample,HasHeaders=true, InferRows=10, IgnoreErrors=true>
let StockData symbol = StockProvider.Load(sprintf "%s%s" url symbol)



