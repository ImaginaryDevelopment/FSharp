module ConceptHelpers
type TaxId = | TaxId of string
let TaxId (input:string) = match input with
                            | x when x<>null && x.Length=11 -> Some(TaxId x)
                            | _ -> None

type CompanyName = {Name:string;Address:string;TaxId:TaxId}

type Adjustment = |Adjustment

type Service = | Service of Adjustment list option
type ServiceList = |ServiceList of Service list
let ServiceList services = match services with
                            | s when s<> list.Empty -> Some(ServiceList(services))
                            | _ -> None

type Claim = | Service of ServiceList
             | Adjustment of Adjustment list
             | Both of Service list *Adjustment list

type Provider = |Provider of Claim list *
                            TaxId option *
                            Adjustment list option

type Payment = |Payment of Provider list * Adjustment list option
let Payment providers adjustments = 
    match (providers,adjustments) with
    | (p,a) when p<>list.Empty -> Some(Payment(providers,adjustments))
    | _ -> None

let samplePayment = Payment list.Empty None
let samplePayment2 = Payment [Provider(list.Empty,None,None)] None


let ProcessPayment providers adjustments =
    let paymentOption = Payment providers adjustments
    
    match paymentOption with
    | Some(payment) -> printfn "yay valid payment %A" payment
    | None -> failwith "Invalid payment"
    //| _ -> ()