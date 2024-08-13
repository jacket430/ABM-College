using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSignup
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            CheckEmail();
        }

        private void CheckEmail()
        {
            string email = emailBox.Text;
            if (Form1.userList.ContainsKey(email))
            {
                passLabel.Show();
                passBox.Show();
                forgotPasswordLabel.Show();
                forgotPasswordLabel.ForeColor = Color.Black;
                forgotPasswordLabel.Text = "Email found. Enter a new password.";
                loginButton.Hide();
                changeButton.Show();
            }
            else
            {
                forgotPasswordLabel.Show();
                forgotPasswordLabel.ForeColor = Color.Red;
                forgotPasswordLabel.Text = "Email not found!";
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text;
            string newPassword = passBox.Text;

            if (Form1.userList.ContainsKey(email))
            {
                Form1.userList[email] = newPassword;

                MessageBox.Show("Password changed! Try logging in again.");

                this.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
