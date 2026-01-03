namespace FoodOrderingSystem.Interfaces
{
    public interface PaymentMethod
    {
        void Pay(double amount);
        string GetPaymentType();
    }
}
