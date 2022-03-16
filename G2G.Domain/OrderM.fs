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


let product1 = Product.Drink(DrinkBase.Coffee({ size = Size.Small; coffeeType = CoffeeType.Cappucino}))
let product2 = Product.Drink(DrinkBase.Coffee({ size = Size.Large; coffeeType = CoffeeType.Americano}))
let product3 = Product.Drink(DrinkBase.Tea({ size = Size.Medium; teaType = TeaType.Herbal}))
let product4 = Product.Drink(DrinkBase.Soda({ size = Size.Small; sodaType = SodaType.Fanta}))
let product5 = Product.Drink(DrinkBase.Juice({ size = Size.Large; juiceType = JuiceType.Mixed}))
let product6 = Product.Fruit(FruitBase.Apple)
let product7 = Product.Fruit(FruitBase.Mango)

let products = product1 :: product2 :: product3 :: product4 :: product5 :: product6 :: product7 :: []
let payment = Payment.CreditCard({ bankAccount = "DK00556699"; amount = 0.0})

let order = { products = products; payment = payment }

payOrder order