namespace FarmersMart.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }

    
}


/*This class defines the properties of a category, such as its name, and description.
 * The Id property is used as the primary key, and the Products property is used to store 
 * the related products.

The ICollection<Product> type is used for the Products property, 
which represents a collection of Product objects.
This allows you to navigate the relationship between categories and products.

It's important to note that this is just a basic example,
and you can add or remove properties as per your requirement.

You could also use some libraries like Entity Framework 
to make it easy for you to interact with the database, 
it will automatically map your POCO classes to the database tables 
using the conventions.*/
