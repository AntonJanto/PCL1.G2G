module OrderM
open ProductM
open PaymentM

type OrderR = { products: Product List; payment: Payment}

let printPayment payment total = 
    match payment with
    | Cash(cashR) -> 
        printfn "The order total %f has been fully paid in cash." total
    | CreditCard(ccR) ->
        printfn "The order total %f has been fully paid using a credit card from account %s." total ccR.bankAccount

let orderProduct (order:OrderR) = calculatePriceTotal order.products |> gtgVAT 25

let payOrder (order:OrderR) = 
    let total = orderProduct order
    printPayment order.payment total

type OrderProductMsg = 
    | Order of OrderR 
    | LeaveAComment of string

let gtgAgent = MailboxProcessor<OrderProductMsg>.Start(fun inbox -> 
    let rec orderProductMessage = async{
        let! msg = inbox.Receive()
        match msg with 
        | Order(orderR) -> payOrder orderR
        | LeaveAComment(leaveAComment) -> printfn"%s" leaveAComment
        return! orderProductMessage
        }
    orderProductMessage)