using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aug28
{
    public partial class Main : Form
    {
        private const string ConnectionString = @"Server=THEISLANDWIN\SQLEXPRESS;Database=MAP;User Id=Avery;Password=Kgass12!@";

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string accountType = GlobalState.AccountType ?? "Unknown";
            toolStripStatusLabel2.Text = "Account Type: " + accountType;

            LoadTransactions();
            UpdateBalanceLabel();
        }

        private void LoadTransactions()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Transactions";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable transactionsTable = new DataTable();
                    adapter.Fill(transactionsTable);
                    dataGridView1.DataSource = transactionsTable;
                }
            }
        }

        private void UpdateBalanceLabel()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Balance FROM Balances WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", GlobalState.Username);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        label2.Text = "$" + result.ToString();
                    }
                    else
                    {
                        label2.Text = "Balance: Not available";
                    }
                }
            }
        }
    }
}
