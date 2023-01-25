namespace FarmersMart.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ICollection<CartItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

//This class defines the properties of a cart, such as its Id, and the UserId of the user
//    who created it. The Items property is used to store a collection of CartItem objects,
//    which represent the products in the cart. The TotalPrice property is used to store the 
//    total cost of all items in the cart.
