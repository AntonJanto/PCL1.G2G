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

let payOrder (order:OrderR) = 
    let total = calculatePriceTotal order.products
    printPayment order.payment total
