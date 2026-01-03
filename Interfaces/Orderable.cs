using FoodOrderingSystem.Models;

namespace FoodOrderingSystem.Interfaces
{
    public interface Orderable
    {
        void AddItem(MenuItem item);
        void RemoveItem(int menuItemId);
        double CalculateTotal();
    }
}
