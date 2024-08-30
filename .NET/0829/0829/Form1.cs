using System.Data;

namespace _0829
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            DataTable walletsData = dbHelper.GetWalletsData();
            dataGridView1.DataSource = walletsData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Populate form = new Populate();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            DataTable walletsData = dbHelper.GetWalletsData();
            dataGridView1.DataSource = walletsData;
        }
    }
}
