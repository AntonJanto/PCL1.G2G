module FirstSpintr
type CoffeeType = Americano | Latte | Cappucino | Espresso
type Teatype = Green | Herbal | Wulong | Camellia
type JuiceType = Apple | Orange | Mixed 
type SodaType = Cola | Fanta | Sprite 

type Size = Small | Medium | Large
type CoffeeR = {size:Size; coffeeType:CoffeeType}
type TeaR = {size:Size; teaType:Teatype}
type JuiceR = {size:Size; teaType: Teatype}
type SodaR = {size:Size; sodaType: SodaType}
type Drink = Coffee of CoffeeR |Tea of TeaR | Juice of JuiceR | Soda of SodaR


let priceSizeCoffee (coffe : CoffeeR) = 
    match coffe.size with 
    | Small -> 10
    | Medium -> 15 
    | Large -> 20

let priceSizeTea (tea : TeaR) = 
    match tea.size with 
    | Small -> 12
    | Medium -> 17 
    | Large -> 20

let priceSizeJuice (juice : JuiceR) = 
    match juice.size with 
    | Small -> 5
    | Medium -> 10 
    | Large -> 15

let priceSizeSoda (soda : SodaR) = 
    match soda.size with
    | Small -> 15
    | Medium -> 18
    | Large -> 21

let priceDrink (drink : Drink) = 
    match drink with 
    | Coffee(coffeeR) -> priceSizeCoffee coffeeR
    | Tea(teaR) -> priceSizeTea teaR
    | Juice(juiceR) -> priceSizeJuice juiceR
    | Soda(sodaR) -> priceSizeSoda sodaR

