using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aug28
{
    internal class AccType
    {
        private const string ConnectionString = @"Server=THEISLANDWIN\SQLEXPRESS;Database=MAP;User Id=Avery;Password=Kgass12!@";
        private string? _accountType;

        public string? GetAccountType(string username)
        {
            if (_accountType != null)
            {
                return _accountType;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT AccountType FROM Users WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    object result = command.ExecuteScalar();
                    _accountType = result?.ToString();
                    GlobalState.AccountType = _accountType; // Store globally
                    return _accountType;
                }
            }
        }
    }
}
