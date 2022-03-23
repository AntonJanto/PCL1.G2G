module PaymentM
open System

type CashR = { amount: float }
type CreditCardR = { amount: float; bankAccount:string }

type Payment = Cash of CashR | CreditCard of CreditCardR

let gtgVAT(percentage : int)(price : float) = price * (1.0 + Convert.ToDouble(percentage)/100.0)  
