using System;
using FoodOrderingSystem.Interfaces;

namespace FoodOrderingSystem.Models
{
    public class CashPayment : PaymentMethod
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Nakit ödeme alındı: {amount} TL");
        }

        public string GetPaymentType()
        {
            return "Nakit";
        }
    }
}
