module Primitives

let array = [|  1;2 |]
let list = [1,"a";2,"b"]
let list2 = [1]

type Author = {FirstName:string;LastName:string;Address:string;ZipCode:string}

let author1 = {FirstName="Robert";LastName="K";Address="301";ZipCode="123"}
let author2 = {author1 with LastName="Kerr"}