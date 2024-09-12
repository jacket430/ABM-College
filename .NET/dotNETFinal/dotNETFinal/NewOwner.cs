using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotNETFinal
{
    public partial class NewOwner : Form
    {
        public NewOwner()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            try
            {
                var owner = new Owner
                {
                    FirstName = firstNameBox.Text.Trim(),
                    LastName = lastNameBox.Text.Trim(),
                    PhoneNumber = phoneNumberBox.Text.Trim(),
                    Email = emailBox.Text.Trim(),
                    Address = addressBox.Text.Trim()
                };

                if (ValidateOwner(owner))
                {
                    InsertOwner(owner);
                    toolStripStatusLabel1.Text = "Owner added successfully!";
                    MessageBox.Show("Owner added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding owner: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Error adding owner.";
            }
        }

        private bool ValidateOwner(Owner owner)
        {
            if (string.IsNullOrWhiteSpace(owner.FirstName) ||
                string.IsNullOrWhiteSpace(owner.LastName) ||
                string.IsNullOrWhiteSpace(owner.PhoneNumber) ||
                string.IsNullOrWhiteSpace(owner.Email) ||
                string.IsNullOrWhiteSpace(owner.Address))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolStripStatusLabel1.Text = "Missing 1 or more required fields!";
                return false;
            }

            // Validate email format
            if (!IsValidEmail(owner.Email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolStripStatusLabel1.Text = "Invalid email format!";
                return false;
            }

            // Validate phone number (only numbers)
            if (!IsValidPhoneNumber(owner.PhoneNumber))
            {
                MessageBox.Show("Please enter a valid phone number (numbers only).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolStripStatusLabel1.Text = "Invalid phone number format!";
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                    + @"([-a-z0-9!#$%&'*+/=?^_{|}~]|(?<!\.)\.)*)(?<!\.)"
                    + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit);
        }

        private void InsertOwner(Owner owner)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlString"].ConnectionString;
            const string query = @"INSERT INTO Owners (FirstName, LastName, PhoneNumber, Email, Address) 
                 VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Address)";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", owner.FirstName);
                command.Parameters.AddWithValue("@LastName", owner.LastName);
                command.Parameters.AddWithValue("@PhoneNumber", owner.PhoneNumber);
                command.Parameters.AddWithValue("@Email", owner.Email);
                command.Parameters.AddWithValue("@Address", owner.Address);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void NewOwner_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}
