module HelloCsvProvider.SqlAdo
//[<Literal>]
//let connectionString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=AdventureWorks2012;Integrated Security=True"
//[<Literal>]
//let query = "
//    SELECT TOP(@TopN) FirstName, LastName, SalesYTD 
//    FROM Sales.vSalesPerson
//    WHERE CountryRegionName = @regionName AND SalesYTD > @salesMoreThan 
//    ORDER BY SalesYTD
//" 
//
//type SalesPersonQuery = SqlCommandProvider<query, connectionString>
//let cmd = new SalesPersonQuery()
//
//cmd.AsyncExecute(TopN = 3L, regionName = "United States", salesMoreThan = 1000000M) 
//|> Async.RunSynchronously

//output
//seq
//    [("Pamela", "Ansman-Wolfe", 1352577.1325M);
//     ("David", "Campbell", 1573012.9383M);
//     ("Tete", "Mensa-Annan", 1576562.1966M)]