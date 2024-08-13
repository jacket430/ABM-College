namespace NewTestProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            UpdateFormOnMove();
        }

        private void maleBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGenderLabel();
        }

        private void femaleBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGenderLabel();
        }

        private void InitializeForm()
        {
            textBox1.Text = "Avery";
            genderLabel.BackColor = Color.Black;
            genderLabel.ForeColor = Color.White;
        }

        private void UpdateFormOnMove()
        {
            checkBox1.Checked = !checkBox1.Checked;
            radioButton1.Checked = true;
            button1.Text = "Avery Hogan";
        }

        private void UpdateGenderLabel()
        {
            if (maleBox.Checked && femaleBox.Checked)
            {
                genderLabel.Text = "Both Male and Female are selected!";
                genderLabel.ForeColor = Color.Blue;
                genderLabel.BackColor = Color.Pink;
            }
            else if (maleBox.Checked)
            {
                genderLabel.Text = "Male is selected!";
                genderLabel.ForeColor = Color.Cyan;
                genderLabel.BackColor = Color.Black;
            }
            else if (femaleBox.Checked)
            {
                genderLabel.Text = "Female is selected!";
                genderLabel.ForeColor = Color.Pink;
                genderLabel.BackColor = Color.Black;
            }
            else
            {
                genderLabel.Text = "Waiting for selection...";
                genderLabel.ForeColor = Color.White;
                genderLabel.BackColor = Color.Black;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
