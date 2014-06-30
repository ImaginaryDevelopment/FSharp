module Sql
type UnaryExpression = 
    | Bool of bool

type Where = | Unary of UnaryExpression