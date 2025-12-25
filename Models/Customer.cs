namespace FoodOrderingSystem.Models
{
    public class Customer : User
    {
        // Encapsulation
        public string Address { get; private set; }
        public string Phone { get; private set; }

        public Customer(int id, string name, string email, string address, string phone)
            : base(id, name, email)
        {
            Address = address;
            Phone = phone;
        }

        public void UpdateAddress(string newAddress)
        {
            Address = newAddress;
        }

        public void UpdatePhone(string newPhone)
        {
            Phone = newPhone;
        }
    }
}
