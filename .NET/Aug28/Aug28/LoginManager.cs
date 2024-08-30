using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Aug28
{
    public class LoginManager
    {
        private const string ConnectionString = @"Server=THEISLANDWIN\SQLEXPRESS;Database=MAP;User Id=Avery;Password=Kgass12!@";

        public bool ValidateCredentials(string username, string password)
        {
            Trace.WriteLine($"Validating credentials for Username: {username}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                Trace.WriteLine("Database connection opened.");
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();
                    Trace.WriteLine($"Credentials validation result for {username}: {(count == 1 ? "Valid" : "Invalid")}");
                    if (count == 1)
                    {
                        AccType accType = new AccType();
                        accType.GetAccountType(username);
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}
