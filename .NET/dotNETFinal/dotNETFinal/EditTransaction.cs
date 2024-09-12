using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dotNETFinal
{
    public partial class EditTransaction : Form
    {
        private Transaction _transactionToEdit;

        public EditTransaction(Transaction transactionToEdit)
        {
            InitializeComponent();
            _transactionToEdit = transactionToEdit;
        }

        private void EditTransaction_Load(object sender, EventArgs e)
        {
            if (!LoadPropertyIDs() || !LoadOwnerIDs())
            {
                MessageBox.Show("Cannot edit the transaction. Ensure there is at least one entry in both Owners and Properties tables.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            toolStripStatusLabel1.Text = "";
            PopulateFields();
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

        private void PopulateFields()
        {
            propertyIDBox.SelectedItem = _transactionToEdit.PropertyID.ToString();
            ownerIDBox.SelectedItem = _transactionToEdit.OwnerID.ToString();
            transactionTypeBox.SelectedItem = _transactionToEdit.TransactionType;
            amountBox.Text = _transactionToEdit.Amount.ToString();
            dateTimePicker1.Value = _transactionToEdit.TransactionDate;
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

        private void UpdateTransaction(Transaction transaction)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlString"].ConnectionString;
            const string query = @"UPDATE Transactions SET PropertyID = @PropertyID, OwnerID = @OwnerID, TransactionDate = @TransactionDate, TransactionType = @TransactionType, Amount = @Amount WHERE TransactionID = @TransactionID";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransactionID", transaction.TransactionID);
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
                MessageBox.Show($"Error updating transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedPropertyID = propertyIDBox.SelectedItem?.ToString();
                var selectedOwnerID = ownerIDBox.SelectedItem?.ToString();
                var selectedTransactionType = transactionTypeBox.SelectedItem?.ToString();
                var amountText = amountBox.Text;

                if (string.IsNullOrWhiteSpace(selectedPropertyID) ||
                    string.IsNullOrWhiteSpace(selectedOwnerID) ||
                    string.IsNullOrWhiteSpace(selectedTransactionType) ||
                    string.IsNullOrWhiteSpace(amountText))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    toolStripStatusLabel1.Text = "Missing 1 or more required fields!";
                    return;
                }

                _transactionToEdit.PropertyID = int.Parse(selectedPropertyID);
                _transactionToEdit.OwnerID = int.Parse(selectedOwnerID);
                _transactionToEdit.TransactionType = selectedTransactionType;
                _transactionToEdit.Amount = decimal.Parse(amountText);
                _transactionToEdit.TransactionDate = dateTimePicker1.Value;

                if (ValidateTransaction(_transactionToEdit))
                {
                    UpdateTransaction(_transactionToEdit);
                    toolStripStatusLabel1.Text = "Transaction updated successfully!";
                    MessageBox.Show("Transaction updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Error updating transaction.";
            }
        }
    }
}
