namespace FarmersMart.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Product Product { get; set; }
    }
}

//This class defines the properties of a cart item, such as its product Id,
//Quantity and price. The Product property is used to store the related product
//object, it will be useful when you want to show the product name and image in the cart.

//It's important to note that this is just a basic example, and you can add or
//remove properties as per your requirement.

//You could also use some libraries like Entity Framework to make it easy for
//you to interact with the database, it will automatically map your POCO classes
//to the database tables using the conventions.
