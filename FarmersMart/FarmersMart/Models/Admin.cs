namespace FarmersMart.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

//This class defines the properties of an admin, such as its Id, username, email, and password. 
//    The Id property is used as the primary key, and the UserName property is used to store 
//    the username of the admin. The Email property is used to store the email of the admin 
//    and the Password property is used to store the hashed version of the admin's password.

//It's important to note that for security reasons, it's not recommended to store the plain 
//    text password in the database. It's recommended to use a library like bcrypt or scrypt
//    to hash the password before storing it.

//It's also important to note that this is just a basic example, and you can add or remove
//    properties as per your requirement.

//You could also use some libraries like Identity Framework to make it easy for you to handle
//    users and admin authentication and authorization.