using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dotNETFinal
{
    public partial class EditOwner : Form
    {
        private readonly Owner _ownerToEdit;

        public EditOwner(Owner ownerToEdit)
        {
            InitializeComponent();
            _ownerToEdit = ownerToEdit;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateOwnerDetails();

                if (ValidateOwner(_ownerToEdit))
                {
                    UpdateOwnerInDatabase(_ownerToEdit);
                    DisplaySuccessMessage();
                    CloseFormWithSuccess();
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }

        private void UpdateOwnerDetails()
        {
            _ownerToEdit.FirstName = firstNameBox.Text.Trim();
            _ownerToEdit.LastName = lastNameBox.Text.Trim();
            _ownerToEdit.PhoneNumber = phoneNumberBox.Text.Trim();
            _ownerToEdit.Email = emailBox.Text.Trim();
            _ownerToEdit.Address = addressBox.Text.Trim();
        }

        private bool ValidateOwner(Owner owner)
        {
            if (string.IsNullOrWhiteSpace(owner.FirstName) ||
                string.IsNullOrWhiteSpace(owner.LastName) ||
                string.IsNullOrWhiteSpace(owner.PhoneNumber) ||
                string.IsNullOrWhiteSpace(owner.Email) ||
                string.IsNullOrWhiteSpace(owner.Address))
            {
                DisplayValidationError();
                return false;
            }
            return true;
        }

        private void UpdateOwnerInDatabase(Owner owner)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlString"].ConnectionString;
            const string query = @"UPDATE Owners 
                                   SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, 
                                       Email = @Email, Address = @Address
                                   WHERE OwnerID = @OwnerID";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OwnerID", owner.OwnerID);
                command.Parameters.AddWithValue("@FirstName", owner.FirstName);
                command.Parameters.AddWithValue("@LastName", owner.LastName);
                command.Parameters.AddWithValue("@PhoneNumber", owner.PhoneNumber);
                command.Parameters.AddWithValue("@Email", owner.Email);
                command.Parameters.AddWithValue("@Address", owner.Address);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void DisplaySuccessMessage()
        {
            toolStripStatusLabel1.Text = "Owner updated successfully!";
            MessageBox.Show("Owner updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CloseFormWithSuccess()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DisplayErrorMessage(string message)
        {
            MessageBox.Show($"Error updating owner: {message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            toolStripStatusLabel1.Text = "Error updating owner.";
        }

        private void DisplayValidationError()
        {
            MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            toolStripStatusLabel1.Text = "Missing 1 or more required fields!";
        }

        private void EditOwner_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            PopulateFields();
        }

        private void PopulateFields()
        {
            firstNameBox.Text = _ownerToEdit.FirstName;
            lastNameBox.Text = _ownerToEdit.LastName;
            phoneNumberBox.Text = _ownerToEdit.PhoneNumber;
            emailBox.Text = _ownerToEdit.Email;
            addressBox.Text = _ownerToEdit.Address;
        }
    }
}
