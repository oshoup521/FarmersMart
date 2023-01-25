namespace FarmersMart.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

//This class defines the properties of an OrderDetails, such as its Id,
//    OrderId, ProductId, Quantity and Price. The Order and Product properties
//    are used to store the related Order and Product objects, it will be useful
//    when you want to show the Order and Product details in the OrderDetails.
