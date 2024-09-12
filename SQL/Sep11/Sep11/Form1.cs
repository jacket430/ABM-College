using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Sep11
{
    public partial class Form1 : Form
    {
        private readonly string connectionString;

        public Form1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var adapter = new SqlDataAdapter("SELECT * FROM Stock", conn))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    toolStripStatusLabel1.Text = "Table loaded.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(idBox.Text, out int itemID) || !int.TryParse(quantityBox.Text, out int quantity))
            {
                MessageBox.Show("Please enter valid Item ID and quantity.");
                return;
            }

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT itemStock FROM Stock WHERE itemID = @ItemID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int itemStock = Convert.ToInt32(result);
                            MessageBox.Show(quantity > itemStock
                                ? $"Error: Requested quantity ({quantity}) exceeds available stock ({itemStock})."
                                : "Checkout successful!");
                        }
                        else
                        {
                            MessageBox.Show("Error: Item ID not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking stock: {ex.Message}");
            }
        }

        private void bulkButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    using (var cmd = new SqlCommand("INSERT INTO Stock (itemName, itemStock) VALUES (@ItemName, @ItemStock)", conn, transaction))
                    {
                        var random = new Random();
                        for (int i = 1; i <= 100; i++)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ItemName", $"Laptop Brand {i}");
                            cmd.Parameters.AddWithValue("@ItemStock", random.Next(1, 21));
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                }
                MessageBox.Show("100 laptops have been added to the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding laptops. No changes were made to the database. Error: {ex.Message}");
            }
            LoadData();
        }

        private void bulkErrorButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    using (var cmd = new SqlCommand("INSERT INTO Stock (itemName, itemStock) VALUES (@ItemName, @ItemStock)", conn, transaction))
                    {
                        var random = new Random();
                        for (int i = 1; i <= 100; i++)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ItemName", $"Error Test Laptop {i}");
                            cmd.Parameters.AddWithValue("@ItemStock", i == 78 ? -1 : random.Next(1, 21));
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                }
                MessageBox.Show("100 laptops have been added to the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding laptops: {ex.Message}\nAll changes have been rolled back.");
            }
            LoadData();
        }

        private void bulkUpdateButton_Click(object sender, EventArgs e)
        {
            string newName = bulkNameBox.Text.Trim();
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Please enter a new name in the bulkNameBox.");
                return;
            }

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    using (var cmd = new SqlCommand("UPDATE Stock SET itemName = @NewName", conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@NewName", newName);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        transaction.Commit();
                        MessageBox.Show($"{rowsAffected} items have been updated in the database.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating item names: {ex.Message}\nNo changes were made to the database.");
            }
            LoadData();
        }

    }
}
