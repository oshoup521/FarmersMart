using BCrypt;

namespace FarmersMart.DAL
{
    public class PasswordManagement
    {
        public static string EncryptPassword(String password) {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        public static bool DecryptPassword(String password,String hashedPassword)
        {
            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            return isPasswordCorrect;
        }
    }
}
