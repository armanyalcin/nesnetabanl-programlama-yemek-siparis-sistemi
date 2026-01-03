using System;
using FoodOrderingSystem.Interfaces;

namespace FoodOrderingSystem.Models
{
    public class CreditCardPayment : PaymentMethod
    {
        public string CardNumber { get; private set; }

        public CreditCardPayment(string cardNumber)
        {
            CardNumber = cardNumber;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"Kredi kartı ile ödeme yapıldı: {amount} TL");
        }

        public string GetPaymentType()
        {
            return "Kredi Kartı";
        }
    }
}
