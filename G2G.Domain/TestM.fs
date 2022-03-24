module TestM
open ProductM
open PaymentM
open OrderM


let product1 = Product.Drink(DrinkBase.Coffee({ size = Size.Small; coffeeType = CoffeeType.Cappucino}), 1)
let product2 = Product.Drink(DrinkBase.Coffee({ size = Size.Large; coffeeType = CoffeeType.Americano}), 1)
let product3 = Product.Drink(DrinkBase.Tea({ size = Size.Medium; teaType = TeaType.Herbal}), 2)
let product4 = Product.Drink(DrinkBase.Soda({ size = Size.Small; sodaType = SodaType.Fanta}), 1)
let product5 = Product.Drink(DrinkBase.Juice({ size = Size.Large; juiceType = JuiceType.Mixed}), 10)
let product6 = Product.Fruit(FruitBase.Apple, 5)
let product7 = Product.Fruit(FruitBase.Mango, 1)

let products = [ product1 ; product2 ; product3 ; product4 ; product5 ; product6 ; product7 ]
let payment = Payment.CreditCard({ bankAccount = "DK00556699"; amount = 0.0})

let order = { products = products; payment = payment }

payOrder order

let orderMsg = OrderProductMsg.Order(order)
gtgAgent.Post(orderMsg)

let comment = "I am leaving a comment"
let commentMsg = OrderProductMsg.LeaveAComment(comment)
gtgAgent.Post(commentMsg)
