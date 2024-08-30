using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public void PopulateDataGridView()
{
    // Connection string to connect to the SQL Server instance
    string connectionString = "Server=THEISLANDWIN\\SQLEXPRESS;Database=MAP;User Id=Avery;Password=Kgass12!@;";

    // SQL query to select all data from the Wallet table
    string query = "SELECT * FROM Wallet";

    // Create a new SqlConnection
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        try
        {
            // Open the connection
            connection.Open();

            // Create a SqlDataAdapter to execute the query and fill the DataTable
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

            // Create a DataTable to hold the query results
            DataTable dataTable = new DataTable();

            // Fill the DataTable with the query results
            dataAdapter.Fill(dataTable);

            // Set the DataSource of dataGridView1 to the DataTable
            dataGridView1.DataSource = dataTable;
        }
        catch (Exception ex)
        {
            // Handle any errors that may have occurred
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }
}
