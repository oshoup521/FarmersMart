using FarmersMart.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace FarmersMart.DAL
{
    

    public class CustomerDAL
    {
        private string _connectionString;

        public CustomerDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM customer";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var customer = new Customer();
                            customer.Id = reader.GetInt32("id");
                            customer.UserId = reader.GetString("UserId");
                            customer.FirstName = reader.GetString("FirstName");
                            customer.LastName = reader.GetString("LastName");
                            customer.Email = reader.GetString("Email");
                            customer.Phone = reader.GetString("Phone");
                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }

        public void InsertCustomer(Customer customer)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            using (MySqlCommand command = new MySqlCommand("INSERT INTO Customer (Name, Email) VALUES (@Name, @Email)", connection))
            {
                command.Parameters.AddWithValue("@UserId", customer.UserId);
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                //UserId, FirstName, LastName, Email, Phone
                string query = "UPDATE customer SET UserId = @userId, FirstName = @firstName, LastName = @lastName, Email = @email, Phone = @phone WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", customer.UserId);
                    command.Parameters.AddWithValue("@firstName", customer.FirstName);
                    command.Parameters.AddWithValue("@lastName", customer.LastName);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    command.Parameters.AddWithValue("@phone", customer.Phone);
                    command.Parameters.AddWithValue("@id", customer.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCustomer(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            using (MySqlCommand command = new MySqlCommand("DELETE FROM Customer WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                Customer customer= null;
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM Customer WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                     if (reader.Read())
                     {
                            customer = new Customer();
                            customer.Id = reader.GetInt32("Id");
                            customer.UserId = reader.GetString("UserId");
                            customer.FirstName = reader.GetString("FirstName");
                            customer.LastName = reader.GetString("LastName");
                            customer.Email = reader.GetString("Email");
                            customer.Phone = reader.GetString("Phone");

                     }
                }
                return customer;  
            }
        }

    }

}
