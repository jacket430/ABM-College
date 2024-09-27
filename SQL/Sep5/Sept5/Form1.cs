using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Sept5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Call the new function with a message
            UpdateStatus("Form1 has loaded successfully.");

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    UpdateStatus("Database connection successful.");
                }
                catch (Exception ex)
                {
                    UpdateStatus("Database connection failed: " + ex.Message);
                }
            }
        }
        private void UpdateStatus(string message)
        {
            Debug.WriteLine(message);
            toolStripStatusLabel1.Text = message;
        }
    }
}
