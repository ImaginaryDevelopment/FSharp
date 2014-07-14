module HelloCsvProvider
open FSharp.Data

open Microsoft.FSharp.Data.TypeProviders


let cvs =  Cvs.GetDataContext()
cvs.DataContext.Log <- System.Console.Out
let query = query {
        for row in cvs.Member_Member do
        join row2 in cvs.Admin_Org on (row.Org_id = row2.Org_id)
        select (row.City, row.First_name,row2.Add_by)
    }

