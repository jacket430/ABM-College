using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Sep16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SqlConnection conn;
        private string connectionString = ConfigurationManager.ConnectionStrings["SQLString"].ConnectionString;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                conn.Open();
                string storedProcedureName = "proc_Person";
                SqlDataAdapter adapter = new SqlDataAdapter(storedProcedureName, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
