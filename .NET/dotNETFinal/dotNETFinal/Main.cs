using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dotNETFinal
{
    public partial class Main : Form
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQLString"].ConnectionString;
        private string _currentTable = string.Empty;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData("Properties");
        }

        private void LoadData(string tableName)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                conn.Open();
                string query = $"SELECT * FROM {tableName}";
                using var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                UpdateStatus($"{tableName} loaded!");
                _currentTable = tableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data from {tableName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatus(string message) => toolStripStatusLabel1.Text = message;

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e) => LoadData("Properties");
        private void ownersToolStripMenuItem_Click(object sender, EventArgs e) => LoadData("Owners");
        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e) => LoadData("Transactions");

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implement about functionality
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implement help functionality
        }

        private void newEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? newForm = _currentTable switch
            {
                "Properties" => new NewProperty(),
                "Owners" => new NewOwner(),
                "Transactions" => new NewTransaction(),
                _ => null
            };

            if (newForm != null)
            {
                using (newForm)
                {
                    newForm.ShowDialog();
                }
                LoadData(_currentTable);
            }
            else
            {
                toolStripStatusLabel1.Text = "Failed to open entry window.";
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentTable))
            {
                LoadData(_currentTable);
                UpdateStatus($"Refreshed {_currentTable} table.");
            }
            else
            {
                UpdateStatus("Failed to refresh. Is a table open?");
            }
        }

        private T? GetSelectedItem<T>() where T : class, new()
        {
            if (dataGridView1.CurrentRow == null) return null;

            var row = dataGridView1.CurrentRow;
            var item = new T();

            foreach (var prop in typeof(T).GetProperties())
            {
                if (row.Cells[prop.Name].Value != null)
                {
                    prop.SetValue(item, Convert.ChangeType(row.Cells[prop.Name].Value, prop.PropertyType));
                }
            }

            return item;
        }

        private void modifyEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                toolStripStatusLabel1.Text = "Please select an item to edit.";
                return;
            }

            Form? editForm = _currentTable switch
            {
                "Properties" => GetSelectedItem<Property>() is Property property ? new EditProperty(property) : null,
                "Owners" => GetSelectedItem<Owner>() is Owner owner ? new EditOwner(owner) : null,
                "Transactions" => GetSelectedItem<Transaction>() is Transaction transaction ? new EditTransaction(transaction) : null,
                _ => null
            };

            if (editForm != null)
            {
                using (editForm)
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData(_currentTable);
                        toolStripStatusLabel1.Text = $"{_currentTable.TrimEnd('s')} updated successfully!";
                    }
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Failed to open edit window.";
            }
        }

        private void deleteEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                UpdateStatus("Please select an item to delete.");
                return;
            }

            string confirmMessage = _currentTable switch
            {
                "Properties" => $"Are you sure you want to delete the property at {GetSelectedItem<Property>()?.Address}?",
                "Owners" => $"Are you sure you want to delete the owner {GetSelectedItem<Owner>()?.FirstName} {GetSelectedItem<Owner>()?.LastName}?",
                "Transactions" => $"Are you sure you want to delete the transaction with ID {GetSelectedItem<Transaction>()?.TransactionID}?",
                _ => string.Empty
            };

            if (string.IsNullOrEmpty(confirmMessage)) return;

            if (MessageBox.Show(confirmMessage, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool success = _currentTable switch
                {
                    "Properties" => DeleteItem("Properties", "PropertyID", GetSelectedItem<Property>()?.PropertyID),
                    "Owners" => DeleteItem("Owners", "OwnerID", GetSelectedItem<Owner>()?.OwnerID),
                    "Transactions" => DeleteItem("Transactions", "TransactionID", GetSelectedItem<Transaction>()?.TransactionID),
                    _ => false
                };

                if (success)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    UpdateStatus($"{_currentTable.TrimEnd('s')} deleted successfully!");
                }
                else
                {
                    UpdateStatus($"Failed to delete {_currentTable.TrimEnd('s')}.");
                }
            }
        }

        private bool DeleteItem(string tableName, string idColumnName, int? id)
        {
            if (id == null) return false;

            try
            {
                using var conn = new SqlConnection(_connectionString);
                conn.Open();
                string query = $"DELETE FROM {tableName} WHERE {idColumnName} = @ID";
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting {tableName.TrimEnd('s')}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
