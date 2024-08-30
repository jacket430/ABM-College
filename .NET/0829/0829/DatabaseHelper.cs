using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0829
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = "Server=THEISLANDWIN\\SQLEXPRESS;Database=Wallets;User Id=Avery;Password=Kgass12!@;";
        }

        public DataTable GetWalletsData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Wallets";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public void AddHardCodedEntries()
        {
            string[] rockstars = { "Freddie Mercury", "David Bowie", "Elvis Presley", "Jimi Hendrix", "Kurt Cobain", "Janis Joplin", "Jim Morrison", "John Lennon", "Mick Jagger", "Paul McCartney" };
            int[] balances = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                for (int i = 0; i < rockstars.Length; i++)
                {
                    string query = "INSERT INTO Wallets (WalletUser, Balance, TransactionDate) VALUES (@WalletUser, @Balance, @TransactionDate)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@WalletUser", rockstars[i]);
                        command.Parameters.AddWithValue("@Balance", balances[i]);
                        command.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
