//PRODUCT
//PRODUCT
//PRODUCT
type Size = Small | Medium | Large

type CoffeeType = Americano | Latte | Cappucino | Espresso
type TeaType = Green | Herbal | Wulong | Camellia
type JuiceType = Apple | Orange | Mixed 
type SodaType = Cola | Fanta | Sprite 

type CoffeeR = {size:Size; coffeeType:CoffeeType}
type TeaR = {size:Size; teaType:TeaType}
type JuiceR = {size:Size; juiceType: JuiceType}
type SodaR = {size:Size; sodaType: SodaType}

type DrinkBase = Coffee of CoffeeR | Tea of TeaR | Juice of JuiceR | Soda of SodaR

let priceSizeCoffee (coffe : CoffeeR) = 
    match coffe.size with 
    | Small -> 10.0
    | Medium -> 15.0
    | Large -> 20.0
    
let priceSizeTea (tea : TeaR) = 
    match tea.size with 
    | Small -> 12.0
    | Medium -> 17.0 
    | Large -> 20.0
    
let priceSizeJuice (juice : JuiceR) = 
    match juice.size with 
    | Small -> 5.0
    | Medium -> 10.0 
    | Large -> 15.0
    
let priceSizeSoda (soda : SodaR) = 
    match soda.size with
    | Small -> 15.0
    | Medium -> 18.0
    | Large -> 21.0

let priceDrink (drink : DrinkBase) = 
    match drink with 
    | Coffee(coffeeR) -> priceSizeCoffee(coffeeR)
    | Tea(teaR) -> priceSizeTea(teaR)
    | Juice(juiceR) -> priceSizeJuice(juiceR)
    | Soda(sodaR) -> priceSizeSoda(sodaR)


type FruitBase = Banana | Apple | Mango

let priceFruit (fruit:FruitBase) = 
    match fruit with
    | Banana -> 5.0
    | Apple -> 3.0
    | Mango -> 7.0


type Product = Drink of DrinkBase*int | Fruit of FruitBase*int

let calculatePrice(product:Product) = 
    match product with
    | Drink(drink, quantity) -> priceDrink(drink) * (float)quantity
    | Fruit(fruit, quantity) -> priceFruit(fruit) * (float)quantity

let calculatePriceTotal(products: Product List) = 
    let rec calcTotalRec pr acc = 
        match pr with
        | [] -> acc
        | hd::tl -> (calculatePrice hd) + acc |> calcTotalRec tl
    calcTotalRec products 0.0


//PAYMENT
//PAYMENT
//PAYMENT
type CashR = { amount: float }
type CreditCardR = { amount: float; bankAccount:string }
    
type Payment = Cash of CashR | CreditCard of CreditCardR


//ORDER
//ORDER
//ORDER



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


//RUNNING
//RUNNING
//RUNNING
//RUNNING


let product1 = Product.Drink(DrinkBase.Coffee({ size = Size.Small; coffeeType = CoffeeType.Cappucino}), 1)
let product2 = Product.Drink(DrinkBase.Coffee({ size = Size.Large; coffeeType = CoffeeType.Americano}), 1)
let product3 = Product.Drink(DrinkBase.Tea({ size = Size.Medium; teaType = TeaType.Herbal}), 2)
let product4 = Product.Drink(DrinkBase.Soda({ size = Size.Small; sodaType = SodaType.Fanta}), 1)
let product5 = Product.Drink(DrinkBase.Juice({ size = Size.Large; juiceType = JuiceType.Mixed}), 10)
let product6 = Product.Fruit(FruitBase.Apple, 5)
let product7 = Product.Fruit(FruitBase.Mango, 1)

let products = product1 :: product2 :: product3 :: product4 :: product5 :: product6 :: product7 :: []
let payment = Payment.CreditCard({ bankAccount = "DK00556699"; amount = 0.0})

let order = { products = products; payment = payment }

payOrder order
    