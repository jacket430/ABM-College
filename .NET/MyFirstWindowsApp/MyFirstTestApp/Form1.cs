namespace MyFirstTestApp
{
    public partial class Form1 : Form
    {
        private bool comboBox2Filled;
        private bool comboBox3Filled;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Hello Avery!";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();
            label2.Text = selectedItem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = textBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2Filled = true;
            CheckValidity();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3Filled = true;
            CheckValidity();
        }

        private void CheckValidity()
        {
            if (comboBox2Filled && comboBox3Filled)
            {
                string selectedItem1 = comboBox2.SelectedItem?.ToString();
                string selectedItem2 = comboBox3.SelectedItem?.ToString();

                if (selectedItem1 != null && selectedItem2 != null && selectedItem1 != selectedItem2)
                {
                    label5.Text = "VALID!";
                    label5.ForeColor = Color.Green;
                }
                else
                {
                    label5.Text = "INVALID!";
                    label5.ForeColor = Color.Red;
                }
            }
        }
    }
}
