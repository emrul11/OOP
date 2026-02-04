
using CreditCardTask;

CreditCard creditCard = new CreditCard("1212121", "abc", "dbbl");

creditCard.PayBill(100_000, "Restaurant");
Console.WriteLine($"Outstanding: {creditCard.OutstandingBalance}");
Console.WriteLine($"Credit Balance: {creditCard.CreditBalance}");

creditCard.Repay(150_000);
Console.WriteLine("After over-repayment:");
Console.WriteLine($"Outstanding: {creditCard.OutstandingBalance}");
Console.WriteLine($"Credit Balance: {creditCard.CreditBalance}");

creditCard.PayBill(20_000, "Supermarket");
Console.WriteLine("After new charge:");
Console.WriteLine($"Outstanding: {creditCard.OutstandingBalance}");
Console.WriteLine($"Credit Balance: {creditCard.CreditBalance}");
