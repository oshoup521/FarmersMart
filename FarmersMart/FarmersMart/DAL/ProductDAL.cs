using FarmersMart.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace FarmersMart.DAL
{
    

    public class ProductDAL
    {
        private string _connectionString;

        public ProductDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetAllProducts()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var products = new List<Product>();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT p.*, c.Id as CategoryId, c.Name as CategoryName FROM Product p JOIN Category c on p.CategoryId = c.Id", connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product();
                        product.Id = reader.GetInt32("Id");
                        product.Name = reader.GetString("Name");
                        product.Description = reader.GetString("Description");
                        product.Price = reader.GetDecimal("Price");
                        product.ImageUrl = reader.GetString("ImageUrl");
                        product.Category = new Category()
                        {
                            Id = reader.GetInt32("CategoryId"),
                            Name = reader.GetString("CategoryName")
                        };
                        products.Add(product);
                    }
                }
                return products;
            }
        }

        public Product GetProductById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                Product product = null;
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT p.*, c.Id as CategoryId, c.Name as CategoryName FROM Product p JOIN Category c on p.CategoryId = c.Id WHERE p.Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product();
                        product.Id = reader.GetInt32("Id");
                        product.Name = reader.GetString("Name");
                        product.Description = reader.GetString("Description");
                        product.Price = reader.GetDecimal("Price");
                        product.ImageUrl = reader.GetString("ImageUrl");
                        product.Category = new Category()
                        {
                            Id = reader.GetInt32("CategoryId"),
                            Name = reader.GetString("CategoryName")
                        };
                    }
                }
                return product;
            }
        }

        public void InsertProduct(Product product)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Product (Name, Description, Price, ImageUrl, CategoryId) VALUES (@Name, @Description, @Price, @ImageUrl, @CategoryId)", connection);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                cmd.Parameters.AddWithValue("@CategoryId", product.Category.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Product SET Name = @Name, Description = @Description, Price = @Price, ImageUrl = @ImageUrl WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Id", product.Id);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
               // cmd.Parameters.AddWithValue("@CategoryId", product.Category.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Product WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

}
