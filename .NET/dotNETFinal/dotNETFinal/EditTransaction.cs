using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dotNETFinal
{
    public partial class EditTransaction : Form
    {
        private readonly Transaction _transactionToEdit;

        public EditTransaction(Transaction transactionToEdit)
        {
            InitializeComponent();
            _transactionToEdit = transactionToEdit;
        }

        private void EditTransaction_Load(object sender, EventArgs e)
        {
            if (!LoadIDs("Properties", "PropertyID", propertyIDBox) || !LoadIDs("Owners", "OwnerID", ownerIDBox))
            {
                MessageBox.Show("Cannot edit the transaction. Ensure there is at least one entry in both Owners and Properties tables.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            toolStripStatusLabel1.Text = "";
            PopulateFields();
        }

        private bool LoadIDs(string tableName, string columnName, ComboBox comboBox)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlString"].ConnectionString;
            string query = $"SELECT {columnName} FROM {tableName}";
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
                            var id = reader[columnName].ToString();
                            if (!string.IsNullOrEmpty(id))
                            {
                                comboBox.Items.Add(id);
                                hasEntries = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {columnName}s: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            const string query = @"UPDATE Transactions 
                                   SET PropertyID = @PropertyID, OwnerID = @OwnerID, TransactionDate = @TransactionDate, 
                                       TransactionType = @TransactionType, Amount = @Amount 
                                   WHERE TransactionID = @TransactionID";

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
                if (!int.TryParse(propertyIDBox.SelectedItem?.ToString(), out int propertyID) ||
                    !int.TryParse(ownerIDBox.SelectedItem?.ToString(), out int ownerID) ||
                    string.IsNullOrWhiteSpace(transactionTypeBox.SelectedItem?.ToString()) ||
                    !decimal.TryParse(amountBox.Text, out decimal amount))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    toolStripStatusLabel1.Text = "Missing 1 or more required fields!";
                    return;
                }

                _transactionToEdit.PropertyID = propertyID;
                _transactionToEdit.OwnerID = ownerID;
                _transactionToEdit.TransactionType = transactionTypeBox.SelectedItem.ToString();
                _transactionToEdit.Amount = amount;
                _transactionToEdit.TransactionDate = dateTimePicker1.Value;

                if (ValidateTransaction(_transactionToEdit))
                {
                    UpdateTransaction(_transactionToEdit);
                    toolStripStatusLabel1.Text = "Transaction updated successfully!";
                    MessageBox.Show("Transaction updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
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
