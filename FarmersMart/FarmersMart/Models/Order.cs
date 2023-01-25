namespace FarmersMart.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

//This class defines the properties of an Order, such as its Id, UserId, OrderDate, 
//    TotalPrice, ShippingAddress and a collection of OrderDetails. The OrderDetails 
//    property is used to store a collection of OrderDetails objects, which represent 
//    the products in the order.