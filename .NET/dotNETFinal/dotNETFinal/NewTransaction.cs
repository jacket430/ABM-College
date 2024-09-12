using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dotNETFinal
{
    public partial class NewTransaction : Form
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlString"].ConnectionString;

        public NewTransaction()
        {
            InitializeComponent();
        }

        private void NewTransaction_Load(object sender, EventArgs e)
        {
            if (!LoadIDs("Properties", "PropertyID", propertyIDBox) || !LoadIDs("Owners", "OwnerID", ownerIDBox))
            {
                MessageBox.Show("Cannot create a new transaction. Ensure there is at least one entry in both Owners and Properties tables.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            toolStripStatusLabel1.Text = "";
        }

        private bool LoadIDs(string tableName, string columnName, ComboBox comboBox)
        {
            const string queryTemplate = "SELECT {0} FROM {1}";
            string query = string.Format(queryTemplate, columnName, tableName);
            bool hasEntries = false;

            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(query, connection);
                connection.Open();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader[columnName].ToString();
                    if (!string.IsNullOrEmpty(id))
                    {
                        comboBox.Items.Add(id);
                        hasEntries = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {columnName}s: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return hasEntries;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (propertyIDBox.SelectedItem == null || ownerIDBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select valid PropertyID and OwnerID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var propertyID = propertyIDBox.SelectedItem.ToString();
                var ownerID = ownerIDBox.SelectedItem.ToString();

                if (string.IsNullOrEmpty(propertyID) || string.IsNullOrEmpty(ownerID))
                {
                    MessageBox.Show("Invalid PropertyID or OwnerID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var transaction = new Transaction
                {
                    PropertyID = int.Parse(propertyID),
                    OwnerID = int.Parse(ownerID),
                    TransactionDate = dateTimePicker1.Value,
                    TransactionType = transactionTypeBox.Text.Trim(),
                    Amount = decimal.Parse(amountBox.Text.Trim())
                };

                if (ValidateTransaction(transaction))
                {
                    InsertTransaction(transaction);
                    toolStripStatusLabel1.Text = "Transaction added successfully!";
                    MessageBox.Show("Transaction added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Error adding transaction.";
            }
        }

        private bool ValidateTransaction(Transaction transaction)
        {
            if (transaction.PropertyID <= 0 ||
                transaction.OwnerID <= 0 ||
                string.IsNullOrWhiteSpace(transaction.TransactionType) ||
                transaction.Amount <= 0)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolStripStatusLabel1.Text = "Missing 1 or more required fields!";
                return false;
            }
            return true;
        }

        private void InsertTransaction(Transaction transaction)
        {
            const string query = @"INSERT INTO Transactions (PropertyID, OwnerID, TransactionDate, TransactionType, Amount) 
                                   VALUES (@PropertyID, @OwnerID, @TransactionDate, @TransactionType, @Amount)";

            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PropertyID", transaction.PropertyID);
                command.Parameters.AddWithValue("@OwnerID", transaction.OwnerID);
                command.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                command.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);
                command.Parameters.AddWithValue("@Amount", transaction.Amount);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
