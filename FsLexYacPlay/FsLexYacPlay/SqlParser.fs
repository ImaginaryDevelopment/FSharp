// Implementation file for parser generated by fsyacc
module SqlParser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
   
open Sql   

// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | ASC
  | DESC
  | SELECT
  | FROM
  | WHERE
  | ORDER
  | BY
  | JOIN
  | INNER
  | LEFT
  | RIGHT
  | ON
  | EQ
  | LT
  | LE
  | GT
  | GE
  | COMMA
  | AND
  | OR
  | FLOAT of (float)
  | INT of (int)
  | ID of (string)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_ASC
    | TOKEN_DESC
    | TOKEN_SELECT
    | TOKEN_FROM
    | TOKEN_WHERE
    | TOKEN_ORDER
    | TOKEN_BY
    | TOKEN_JOIN
    | TOKEN_INNER
    | TOKEN_LEFT
    | TOKEN_RIGHT
    | TOKEN_ON
    | TOKEN_EQ
    | TOKEN_LT
    | TOKEN_LE
    | TOKEN_GT
    | TOKEN_GE
    | TOKEN_COMMA
    | TOKEN_AND
    | TOKEN_OR
    | TOKEN_FLOAT
    | TOKEN_INT
    | TOKEN_ID
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_columnList
    | NONTERM_joinList
    | NONTERM_joinClause
    | NONTERM_joinOnClause
    | NONTERM_conditionList
    | NONTERM_whereClause
    | NONTERM_op
    | NONTERM_value
    | NONTERM_orderByClause
    | NONTERM_orderByList
    | NONTERM_orderBy

// This function maps tokens to integers indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | ASC  -> 1 
  | DESC  -> 2 
  | SELECT  -> 3 
  | FROM  -> 4 
  | WHERE  -> 5 
  | ORDER  -> 6 
  | BY  -> 7 
  | JOIN  -> 8 
  | INNER  -> 9 
  | LEFT  -> 10 
  | RIGHT  -> 11 
  | ON  -> 12 
  | EQ  -> 13 
  | LT  -> 14 
  | LE  -> 15 
  | GT  -> 16 
  | GE  -> 17 
  | COMMA  -> 18 
  | AND  -> 19 
  | OR  -> 20 
  | FLOAT _ -> 21 
  | INT _ -> 22 
  | ID _ -> 23 

// This function maps integers indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_ASC 
  | 2 -> TOKEN_DESC 
  | 3 -> TOKEN_SELECT 
  | 4 -> TOKEN_FROM 
  | 5 -> TOKEN_WHERE 
  | 6 -> TOKEN_ORDER 
  | 7 -> TOKEN_BY 
  | 8 -> TOKEN_JOIN 
  | 9 -> TOKEN_INNER 
  | 10 -> TOKEN_LEFT 
  | 11 -> TOKEN_RIGHT 
  | 12 -> TOKEN_ON 
  | 13 -> TOKEN_EQ 
  | 14 -> TOKEN_LT 
  | 15 -> TOKEN_LE 
  | 16 -> TOKEN_GT 
  | 17 -> TOKEN_GE 
  | 18 -> TOKEN_COMMA 
  | 19 -> TOKEN_AND 
  | 20 -> TOKEN_OR 
  | 21 -> TOKEN_FLOAT 
  | 22 -> TOKEN_INT 
  | 23 -> TOKEN_ID 
  | 26 -> TOKEN_end_of_input
  | 24 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstart 
    | 1 -> NONTERM_start 
    | 2 -> NONTERM_columnList 
    | 3 -> NONTERM_columnList 
    | 4 -> NONTERM_joinList 
    | 5 -> NONTERM_joinList 
    | 6 -> NONTERM_joinList 
    | 7 -> NONTERM_joinClause 
    | 8 -> NONTERM_joinClause 
    | 9 -> NONTERM_joinClause 
    | 10 -> NONTERM_joinOnClause 
    | 11 -> NONTERM_joinOnClause 
    | 12 -> NONTERM_conditionList 
    | 13 -> NONTERM_conditionList 
    | 14 -> NONTERM_conditionList 
    | 15 -> NONTERM_whereClause 
    | 16 -> NONTERM_whereClause 
    | 17 -> NONTERM_op 
    | 18 -> NONTERM_op 
    | 19 -> NONTERM_op 
    | 20 -> NONTERM_op 
    | 21 -> NONTERM_op 
    | 22 -> NONTERM_value 
    | 23 -> NONTERM_value 
    | 24 -> NONTERM_value 
    | 25 -> NONTERM_orderByClause 
    | 26 -> NONTERM_orderByClause 
    | 27 -> NONTERM_orderByList 
    | 28 -> NONTERM_orderByList 
    | 29 -> NONTERM_orderBy 
    | 30 -> NONTERM_orderBy 
    | 31 -> NONTERM_orderBy 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 26 
let _fsyacc_tagOfErrorTerminal = 24

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | ASC  -> "ASC" 
  | DESC  -> "DESC" 
  | SELECT  -> "SELECT" 
  | FROM  -> "FROM" 
  | WHERE  -> "WHERE" 
  | ORDER  -> "ORDER" 
  | BY  -> "BY" 
  | JOIN  -> "JOIN" 
  | INNER  -> "INNER" 
  | LEFT  -> "LEFT" 
  | RIGHT  -> "RIGHT" 
  | ON  -> "ON" 
  | EQ  -> "EQ" 
  | LT  -> "LT" 
  | LE  -> "LE" 
  | GT  -> "GT" 
  | GE  -> "GE" 
  | COMMA  -> "COMMA" 
  | AND  -> "AND" 
  | OR  -> "OR" 
  | FLOAT _ -> "FLOAT" 
  | INT _ -> "INT" 
  | ID _ -> "ID" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | ASC  -> (null : System.Object) 
  | DESC  -> (null : System.Object) 
  | SELECT  -> (null : System.Object) 
  | FROM  -> (null : System.Object) 
  | WHERE  -> (null : System.Object) 
  | ORDER  -> (null : System.Object) 
  | BY  -> (null : System.Object) 
  | JOIN  -> (null : System.Object) 
  | INNER  -> (null : System.Object) 
  | LEFT  -> (null : System.Object) 
  | RIGHT  -> (null : System.Object) 
  | ON  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | COMMA  -> (null : System.Object) 
  | AND  -> (null : System.Object) 
  | OR  -> (null : System.Object) 
  | FLOAT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | INT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | ID _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 1us; 65535us; 2us; 3us; 2us; 65535us; 5us; 6us; 13us; 14us; 2us; 65535us; 5us; 13us; 13us; 13us; 3us; 65535us; 17us; 18us; 21us; 22us; 25us; 26us; 4us; 65535us; 27us; 28us; 32us; 33us; 34us; 35us; 36us; 37us; 1us; 65535us; 6us; 7us; 1us; 65535us; 29us; 30us; 5us; 65535us; 27us; 29us; 30us; 31us; 32us; 29us; 34us; 29us; 36us; 29us; 1us; 65535us; 7us; 8us; 2us; 65535us; 47us; 48us; 50us; 51us; 2us; 65535us; 47us; 49us; 50us; 49us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 5us; 8us; 11us; 15us; 20us; 22us; 24us; 30us; 32us; 35us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 1us; 1us; 2us; 1us; 3us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 2us; 1us; 3us; 1us; 3us; 2us; 5us; 6us; 1us; 6us; 1us; 7us; 1us; 7us; 1us; 7us; 1us; 7us; 1us; 8us; 1us; 8us; 1us; 8us; 1us; 8us; 1us; 9us; 1us; 9us; 1us; 9us; 1us; 9us; 1us; 11us; 1us; 11us; 3us; 12us; 13us; 14us; 3us; 12us; 13us; 14us; 3us; 12us; 13us; 14us; 1us; 13us; 1us; 13us; 1us; 14us; 1us; 14us; 1us; 16us; 1us; 16us; 1us; 17us; 1us; 18us; 1us; 19us; 1us; 20us; 1us; 21us; 1us; 22us; 1us; 23us; 1us; 24us; 1us; 26us; 1us; 26us; 1us; 26us; 2us; 27us; 28us; 1us; 28us; 1us; 28us; 3us; 29us; 30us; 31us; 1us; 30us; 1us; 31us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 6us; 9us; 11us; 13us; 15us; 17us; 19us; 21us; 23us; 25us; 27us; 30us; 32us; 34us; 36us; 38us; 40us; 42us; 44us; 46us; 48us; 50us; 52us; 54us; 56us; 58us; 60us; 64us; 68us; 72us; 74us; 76us; 78us; 80us; 82us; 84us; 86us; 88us; 90us; 92us; 94us; 96us; 98us; 100us; 102us; 104us; 106us; 109us; 111us; 113us; 117us; 119us; |]
let _fsyacc_action_rows = 55
let _fsyacc_actionTableElements = [|1us; 32768us; 3us; 2us; 0us; 49152us; 1us; 32768us; 23us; 10us; 2us; 32768us; 4us; 4us; 18us; 11us; 1us; 32768us; 23us; 5us; 3us; 16388us; 9us; 15us; 10us; 19us; 11us; 23us; 1us; 16399us; 5us; 36us; 1us; 16409us; 6us; 46us; 1us; 32768us; 0us; 9us; 0us; 16385us; 0us; 16386us; 1us; 32768us; 23us; 12us; 0us; 16387us; 3us; 16388us; 9us; 15us; 10us; 19us; 11us; 23us; 0us; 16390us; 1us; 32768us; 8us; 16us; 1us; 32768us; 23us; 17us; 1us; 16394us; 12us; 27us; 0us; 16391us; 1us; 32768us; 8us; 20us; 1us; 32768us; 23us; 21us; 1us; 16394us; 12us; 27us; 0us; 16392us; 1us; 32768us; 8us; 24us; 1us; 32768us; 23us; 25us; 1us; 16394us; 12us; 27us; 0us; 16393us; 3us; 32768us; 21us; 44us; 22us; 43us; 23us; 45us; 0us; 16395us; 5us; 32768us; 13us; 38us; 14us; 39us; 15us; 40us; 16us; 41us; 17us; 42us; 3us; 32768us; 21us; 44us; 22us; 43us; 23us; 45us; 2us; 16396us; 19us; 32us; 20us; 34us; 3us; 32768us; 21us; 44us; 22us; 43us; 23us; 45us; 0us; 16397us; 3us; 32768us; 21us; 44us; 22us; 43us; 23us; 45us; 0us; 16398us; 3us; 32768us; 21us; 44us; 22us; 43us; 23us; 45us; 0us; 16400us; 0us; 16401us; 0us; 16402us; 0us; 16403us; 0us; 16404us; 0us; 16405us; 0us; 16406us; 0us; 16407us; 0us; 16408us; 1us; 32768us; 7us; 47us; 1us; 32768us; 23us; 52us; 0us; 16410us; 1us; 16411us; 18us; 50us; 1us; 32768us; 23us; 52us; 0us; 16412us; 2us; 16413us; 1us; 53us; 2us; 54us; 0us; 16414us; 0us; 16415us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 2us; 3us; 5us; 8us; 10us; 14us; 16us; 18us; 20us; 21us; 22us; 24us; 25us; 29us; 30us; 32us; 34us; 36us; 37us; 39us; 41us; 43us; 44us; 46us; 48us; 50us; 51us; 55us; 56us; 62us; 66us; 69us; 73us; 74us; 78us; 79us; 83us; 84us; 85us; 86us; 87us; 88us; 89us; 90us; 91us; 92us; 94us; 96us; 97us; 99us; 101us; 102us; 105us; 106us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 8us; 1us; 3us; 0us; 1us; 2us; 4us; 4us; 4us; 0us; 2us; 3us; 5us; 5us; 0us; 2us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 0us; 3us; 1us; 3us; 1us; 2us; 2us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 3us; 3us; 3us; 4us; 4us; 4us; 5us; 5us; 6us; 6us; 6us; 7us; 7us; 8us; 8us; 8us; 8us; 8us; 9us; 9us; 9us; 10us; 10us; 11us; 11us; 12us; 12us; 12us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16385us; 16386us; 65535us; 16387us; 65535us; 16390us; 65535us; 65535us; 65535us; 16391us; 65535us; 65535us; 65535us; 16392us; 65535us; 65535us; 65535us; 16393us; 65535us; 16395us; 65535us; 65535us; 65535us; 65535us; 16397us; 65535us; 16398us; 65535us; 16400us; 16401us; 16402us; 16403us; 16404us; 16405us; 16406us; 16407us; 16408us; 65535us; 65535us; 16410us; 65535us; 65535us; 16412us; 65535us; 16414us; 16415us; |]
let _fsyacc_reductions ()  =    [| 
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Sql.sqlStatement)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startstart));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'columnList)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : 'joinList)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : 'whereClause)) in
            let _7 = (let data = parseState.GetInput(7) in (Microsoft.FSharp.Core.Operators.unbox data : 'orderByClause)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                     
                                                     { Table = _4;   
                                                       Columns = List.rev _2;   
                                                       Joins = _5;   
                                                       Where = _6;   
                                                       OrderBy = _7 }   
                                                 
                   )
                 : Sql.sqlStatement));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                   [_1]
                   )
                 : 'columnList));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'columnList)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                  _3 :: _1 
                   )
                 : 'columnList));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           [] 
                   )
                 : 'joinList));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'joinClause)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           [_1] 
                   )
                 : 'joinList));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'joinClause)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'joinList)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           _1 :: _2 
                   )
                 : 'joinList));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'joinOnClause)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           _3, Inner, _4 
                   )
                 : 'joinClause));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'joinOnClause)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           _3, Left, _4 
                   )
                 : 'joinClause));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'joinOnClause)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           _3, Right, _4 
                   )
                 : 'joinClause));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           None 
                   )
                 : 'joinOnClause));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionList)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           Some(_2) 
                   )
                 : 'joinOnClause));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'value)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'op)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'value)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                               Cond(_1, _2, _3) 
                   )
                 : 'conditionList));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'value)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'op)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'value)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionList)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                               And(Cond(_1, _2, _3), _5) 
                   )
                 : 'conditionList));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'value)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'op)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'value)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionList)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                               Or(Cond(_1, _2, _3), _5) 
                   )
                 : 'conditionList));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           None 
                   )
                 : 'whereClause));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionList)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           Some(_2) 
                   )
                 : 'whereClause));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                              Eq 
                   )
                 : 'op));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                          Lt 
                   )
                 : 'op));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                      Le 
                   )
                 : 'op));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                                  Gt 
                   )
                 : 'op));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                                              Ge 
                   )
                 : 'op));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                   Int(_1) 
                   )
                 : 'value));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : float)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                   Float(_1) 
                   )
                 : 'value));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                   String(_1) 
                   )
                 : 'value));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           [] 
                   )
                 : 'orderByClause));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'orderByList)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           _3 
                   )
                 : 'orderByClause));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'orderBy)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           [_1] 
                   )
                 : 'orderByList));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'orderBy)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'orderByList)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           _1 :: _3 
                   )
                 : 'orderByList));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           _1, Asc 
                   )
                 : 'orderBy));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           _1, Asc 
                   )
                 : 'orderBy));
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                                                           _1, Desc
                   )
                 : 'orderBy));
|]
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 27;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let start lexer lexbuf : Sql.sqlStatement =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))