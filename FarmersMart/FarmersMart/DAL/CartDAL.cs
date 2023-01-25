using FarmersMart.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace FarmersMart.DAL
{


    public class CartDAL
    {
        private string _connectionString;

        public CartDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Cart GetCartByUserId(int userId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var cart = new Cart();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT c.*, ci.*, p.* FROM Cart c JOIN CartItem ci ON c.Id = ci.CartId JOIN Product p ON ci.ProductId = p.Id WHERE c.UserId = @UserId", connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (cart.Id == 0)
                        {
                            cart.Id = reader.GetInt32("Id");
                            cart.UserId = reader.GetString("UserId");
                            cart.Items = new List<CartItem>();
                        }
                        var cartItem = new CartItem();
                        cartItem.Id = reader.GetInt32("Id");
                        cartItem.ProductId = reader.GetInt32("ProductId");
                        cartItem.Quantity = reader.GetInt32("Quantity");
                        cartItem.Price = reader.GetDecimal("Price");
                        cartItem.Product = new Product()
                        {
                            Id = reader.GetInt32("ProductId"),
                            Name = reader.GetString("Name"),
                            Description = reader.GetString("Description"),
                            Price = reader.GetDecimal("Price"),
                            ImageUrl = reader.GetString("ImageUrl")
                        };
                        cart.Items.Add(cartItem);
                    }
                }
                return cart;
            }
        }

        public void InsertCart(Cart cart)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Cart (UserId) VALUES (@UserId)", connection);
                cmd.Parameters.AddWithValue("@UserId", cart.UserId);
                cmd.ExecuteNonQuery();
                cart.Id = (int)cmd.LastInsertedId;
                foreach (var item in cart.Items)
                {
                    cmd = new MySqlCommand("INSERT INTO CartItem (CartId, ProductId, Quantity, Price) VALUES (@CartId, @ProductId, @Quantity, @Price)", connection);
                    cmd.Parameters.AddWithValue("@CartId", cart.Id);
                    cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void UpdateCart(Cart cart)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM CartItem WHERE CartId = @CartId", connection);
                cmd.Parameters.AddWithValue("@CartId", cart.Id);
                cmd.ExecuteNonQuery();
                foreach (var item in cart.Items)
                {
                    cmd = new MySqlCommand("INSERT INTO CartItem (CartId, ProductId, Quantity, Price) VALUES (@CartId, @ProductId, @Quantity, @Price)", connection);
                    cmd.Parameters.AddWithValue("@CartId", cart.Id);
                    cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCart(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Cart WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
