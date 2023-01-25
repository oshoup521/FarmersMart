namespace FarmersMart.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

/*This class defines the properties of a product, such as its name, description,
 * price, and image URL. The Id property is used as the primary key, and the 
 * CategoryId property is used to store the product's category. 
 * The Category property is used to store the related category object.

It's important to note that this is just a basic example, and you
can add or remove properties as per your requirement.

You could also use some libraries like Entity Framework to 
make it easy for you to interact with the database, 
it will automatically map your POCO classes to the database tables 
using the conventions.*/
