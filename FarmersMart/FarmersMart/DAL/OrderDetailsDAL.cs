using FarmersMart.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace FarmersMart.DAL;
public class OrderDetailsDAL
{
    private string _connectionString;

    public OrderDetailsDAL(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<OrderDetails> GetOrderDetailsByOrderId(int orderId)
    {
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            var orderDetails = new List<OrderDetails>();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT od.*, o.Id as OrderId, o.Date as OrderDate, p.Id as ProductId, p.Name as ProductName, p.Description as ProductDescription, p.Price as ProductPrice, p.ImageUrl as ProductImageUrl FROM OrderDetails od JOIN `Order` o ON od.OrderId = o.Id JOIN Product p on od.ProductId = p.Id WHERE od.OrderId = @OrderId", connection);
            cmd.Parameters.AddWithValue("@OrderId", orderId);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var orderDetail = new OrderDetails();
                    orderDetail.Id = reader.GetInt32("Id");
                    orderDetail.OrderId = reader.GetInt32("OrderId");
                    orderDetail.ProductId = reader.GetInt32("ProductId");
                    orderDetail.Quantity = reader.GetInt32("Quantity");
                    orderDetail.Price = reader.GetDecimal("Price");
                    orderDetail.Order = new Order()
                    {
                        Id = reader.GetInt32("OrderId"),
                        OrderDate = reader.GetDateTime("OrderDate")
                    };
                    orderDetail.Product = new Product()
                    {
                        Id = reader.GetInt32("ProductId"),
                        Name = reader.GetString("ProductName"),
                        Description = reader.GetString("ProductDescription"),
                        Price = reader.GetDecimal("ProductPrice"),
                        ImageUrl = reader.GetString("ProductImageUrl")
                    };
                    orderDetails.Add(orderDetail);
                }
            }
            return orderDetails;
        }
    }

    public void InsertOrderDetails(OrderDetails orderDetail)
    {
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO OrderDetails (OrderId, ProductId, Quantity, Price) VALUES (@OrderId, @ProductId, @Quantity, @Price)", connection);
            cmd.Parameters.AddWithValue("@OrderId", orderDetail.OrderId);
            cmd.Parameters.AddWithValue("@ProductId", orderDetail.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
            cmd.Parameters.AddWithValue("@Price", orderDetail.Price);
            cmd.ExecuteNonQuery();
        }
    }

    public void UpdateOrderDetails(OrderDetails orderDetail)
    {
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE OrderDetails SET OrderId = @OrderId, ProductId = @ProductId, Quantity = @Quantity, Price = @Price WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", orderDetail.Id);
            cmd.Parameters.AddWithValue("@OrderId", orderDetail.OrderId);
            cmd.Parameters.AddWithValue("@ProductId", orderDetail.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
            cmd.Parameters.AddWithValue("@Price", orderDetail.Price);
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteOrderDetails(int id)
    {
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM OrderDetails WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}



