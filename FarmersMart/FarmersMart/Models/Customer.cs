namespace FarmersMart.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

//This class defines the properties of a customer, such as its
//    Id, UserId, FirstName, LastName, Email, Phone and a collection of Orders.
//    The Orders property is used to store a collection of Order objects, 
//    which represent the orders made by the customer.

//It's important to note that this is just a basic example,
//    and you can add or remove properties as per your requirement.
