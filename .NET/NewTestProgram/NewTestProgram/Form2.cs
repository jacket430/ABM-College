using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTestProgram
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // Verify that a username has been entered
            if (string.IsNullOrEmpty(usernameBox.Text))
            {
                errorLabel.Visible = true;
                errorLabel.Text = "Make sure you have entered a username!";
                return;
            }

            // Verify that a password has been entered
            if (string.IsNullOrEmpty(passwordBox.Text))
            {
                errorLabel.Visible = true;
                errorLabel.Text = "Make sure you have entered a password!";
                return;
            }

            // Verify that a city has been entered
            if (string.IsNullOrEmpty(cityBox.Text))
            {
                errorLabel.Visible = true;
                errorLabel.Text = "Make sure you have entered a City!";
                return;
            }

            // Verify that a webserver has been selected
            if (webserverBox.SelectedIndex == -1)
            {
                errorLabel.Visible = true;
                errorLabel.Text = "Make sure you have selected a Web Server!";
                return;
            }

            // Verify that one role has been selected
            if (!roleButton1.Checked && !roleButton2.Checked && !roleButton3.Checked && !roleButton4.Checked)
            {
                errorLabel.Visible = true;
                errorLabel.Text = "Make sure you have specified your role!";
                return;
            }

            // Verify that at least one department has been selected
            if (!departmentCheck1.Checked && !departmentCheck2.Checked && !departmentCheck3.Checked)
            {
                errorLabel.Visible = true;
                errorLabel.Text = "Make sure you have selected at least one department!";
                return;
            }

            // All verifications passed, run DisplaySelectedOptions
            errorLabel.Visible = false;
            DisplaySelectedOptions();
        }

        private void DisplaySelectedOptions()
        {
            StringBuilder message = new StringBuilder();

            // Append the selected username
            if (!string.IsNullOrEmpty(usernameBox.Text))
            {
                message.AppendLine("Username: " + usernameBox.Text);
            }

            // Append the selected password
            if (!string.IsNullOrEmpty(passwordBox.Text))
            {
                message.AppendLine("Password: " + passwordBox.Text);
            }

            // Append the selected city
            if (!string.IsNullOrEmpty(cityBox.Text))
            {
                message.AppendLine("City: " + cityBox.Text);
            }

            // Append the selected webserver
            if (webserverBox.SelectedIndex != -1)
            {
                message.AppendLine("Webserver: " + webserverBox.SelectedItem.ToString());
            }

            // Append the selected role
            if (roleButton1.Checked)
            {
                message.AppendLine("Role: Admin");
            }
            else if (roleButton2.Checked)
            {
                message.AppendLine("Role: Engineer");
            }
            else if (roleButton3.Checked)
            {
                message.AppendLine("Role: Manager");
            }
            else if (roleButton4.Checked)
            {
                message.AppendLine("Role: Guest");
            }

            // Append the selected departments
            if (departmentCheck1.Checked)
            {
                message.AppendLine("Department: Mail");
            }
            if (departmentCheck2.Checked)
            {
                message.AppendLine("Department: Payroll");
            }
            if (departmentCheck3.Checked)
            {
                message.AppendLine("Department: Self-Service");
            }

            // Display the selected options in a pop-up window
            MessageBox.Show(message.ToString());
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            passwordBox.PasswordChar = '*';
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            // Reset all input fields to empty values
            usernameBox.Text = string.Empty;
            passwordBox.Text = string.Empty;
            cityBox.Text = string.Empty;
            webserverBox.SelectedIndex = -1;
            roleButton1.Checked = false;
            roleButton2.Checked = false;
            roleButton3.Checked = false;
            roleButton4.Checked = false;
            departmentCheck1.Checked = false;
            departmentCheck2.Checked = false;
            departmentCheck3.Checked = false;
            errorLabel.Visible = false;
        }
    }
}
