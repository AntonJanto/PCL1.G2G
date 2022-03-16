module PaymentM

type CashR = { amount: float }
type CreditCardR = { amount: float; bankAccount:string }

type Payment = Cash of CashR | CreditCard of CreditCardR
