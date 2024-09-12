using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dotNETFinal
{
    public partial class NewTransaction : Form
    {
        public NewTransaction()
        {
            InitializeComponent();
        }

        private void NewTransaction_Load(object sender, EventArgs e)
        {
            if (!LoadPropertyIDs() || !LoadOwnerIDs())
            {
                MessageBox.Show("Cannot create a new transaction. Ensure there is at least one entry in both Owners and Properties tables.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            toolStripStatusLabel1.Text = "";
        }

        private bool LoadPropertyIDs()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlString"].ConnectionString;
            const string query = "SELECT PropertyID FROM Properties";
            bool hasEntries = false;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var propertyID = reader["PropertyID"].ToString();
                            if (!string.IsNullOrEmpty(propertyID))
                            {
                                propertyIDBox.Items.Add(propertyID);
                                hasEntries = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Property IDs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return hasEntries;
        }

        private bool LoadOwnerIDs()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlString"].ConnectionString;
            const string query = "SELECT OwnerID FROM Owners";
            bool hasEntries = false;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var ownerID = reader["OwnerID"].ToString();
                            if (!string.IsNullOrEmpty(ownerID))
                            {
                                ownerIDBox.Items.Add(ownerID);
                                hasEntries = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Owner IDs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var propertyID = propertyIDBox.SelectedItem?.ToString();
                var ownerID = ownerIDBox.SelectedItem?.ToString();

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
                    this.DialogResult = DialogResult.OK;
                    this.Close();
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
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlString"].ConnectionString;
            const string query = @"INSERT INTO Transactions (PropertyID, OwnerID, TransactionDate, TransactionType, Amount) 
                                   VALUES (@PropertyID, @OwnerID, @TransactionDate, @TransactionType, @Amount)";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PropertyID", transaction.PropertyID);
                    command.Parameters.AddWithValue("@OwnerID", transaction.OwnerID);
                    command.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                    command.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
