module ProductM
open System

let gtgVAT(percentage : int)(price : float) = price * (1.0 + Convert.ToDouble(percentage)/100.0) 

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
    | Coffee(coffeeR) -> priceSizeCoffee(coffeeR) |> gtgVAT 25
    | Tea(teaR) -> priceSizeTea(teaR)
    | Juice(juiceR) -> priceSizeJuice(juiceR)
    | Soda(sodaR) -> priceSizeSoda(sodaR)


type FruitBase = Banana | Apple | Mango

let priceFruit (fruit:FruitBase) = 
    match fruit with
    | Banana -> 5.0
    | Apple -> 3.0
    | Mango -> 7.0


type Product = 
    | Drink of DrinkBase * qty: int 
    | Fruit of FruitBase * qty: int 

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
