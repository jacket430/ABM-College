using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Aug26
{
    public partial class Form1 : Form
    {
        private const string ConnectionString = @"Server=THEISLANDWIN\SQLEXPRESS;Database=ABMTest;User Id=Avery;Password=Kgass12!@";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(string searchQuery = "", bool endsWith = false)
        {
            string query = "SELECT CountryID, CountryName, Score FROM Country";

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query += " WHERE CountryName LIKE @CountryName";
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        if (!string.IsNullOrEmpty(searchQuery))
                        {
                            string parameterValue = endsWith ? "%" + searchQuery : "%" + searchQuery + "%";
                            adapter.SelectCommand.Parameters.AddWithValue("@CountryName", parameterValue);
                        }

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;
                        comboBox1.DataSource = dt;
                        comboBox1.DisplayMember = "CountryName";
                        comboBox1.ValueMember = "CountryID";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchQuery = textBox1.Text.Trim();
            LoadData(searchQuery);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchQuery = textBox1.Text.Trim();
            LoadData(searchQuery, endsWith: true);
        }
    }
}
