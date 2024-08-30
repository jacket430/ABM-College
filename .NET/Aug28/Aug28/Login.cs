using System.Diagnostics;

namespace Aug28
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            LoginManager loginManager = new LoginManager();
            if (loginManager.ValidateCredentials(username, password))
            {
                GlobalState.Username = username;

                Main mainForm = new Main();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
