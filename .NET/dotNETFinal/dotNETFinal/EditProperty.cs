using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dotNETFinal
{
    public partial class EditProperty : Form
    {
        private readonly Property _propertyToEdit;

        public EditProperty(Property propertyToEdit)
        {
            InitializeComponent();
            _propertyToEdit = propertyToEdit;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                UpdatePropertyDetails();

                if (ValidateProperty(_propertyToEdit))
                {
                    UpdatePropertyInDatabase(_propertyToEdit);
                    DisplaySuccessMessage();
                    CloseFormWithSuccess();
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }

        private void UpdatePropertyDetails()
        {
            _propertyToEdit.Address = addressBox.Text.Trim();
            _propertyToEdit.City = cityBox.Text.Trim();
            _propertyToEdit.State = stateBox.SelectedItem?.ToString() ?? string.Empty;
            _propertyToEdit.ZipCode = zipBox.Text.Trim();
            _propertyToEdit.Price = decimal.TryParse(priceBox.Text, out decimal price) ? price : 0m;
            _propertyToEdit.Type = typeBox.SelectedItem?.ToString() ?? string.Empty;
            _propertyToEdit.Bedrooms = (int)bedroomNumber.Value;
            _propertyToEdit.Bathrooms = (int)bathroomNumber.Value;
            _propertyToEdit.Description = descriptionBox.Text.Trim();
            _propertyToEdit.ListingDate = dateBox.Value;
        }

        private bool ValidateProperty(Property property)
        {
            if (string.IsNullOrWhiteSpace(property.Address) ||
                string.IsNullOrWhiteSpace(property.City) ||
                string.IsNullOrWhiteSpace(property.State) ||
                string.IsNullOrWhiteSpace(property.ZipCode) ||
                property.Price <= 0 ||
                string.IsNullOrWhiteSpace(property.Type))
            {
                DisplayValidationError();
                return false;
            }
            return true;
        }

        private void UpdatePropertyInDatabase(Property property)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlString"].ConnectionString;
            const string query = @"UPDATE Properties 
                                   SET Address = @Address, City = @City, State = @State, ZipCode = @ZipCode, 
                                       Price = @Price, Type = @Type, Bedrooms = @Bedrooms, Bathrooms = @Bathrooms, 
                                       Description = @Description, ListingDate = @ListingDate
                                   WHERE PropertyID = @PropertyID";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PropertyID", property.PropertyID);
                command.Parameters.AddWithValue("@Address", property.Address);
                command.Parameters.AddWithValue("@City", property.City);
                command.Parameters.AddWithValue("@State", property.State);
                command.Parameters.AddWithValue("@ZipCode", property.ZipCode);
                command.Parameters.AddWithValue("@Price", property.Price);
                command.Parameters.AddWithValue("@Type", property.Type);
                command.Parameters.AddWithValue("@Bedrooms", property.Bedrooms);
                command.Parameters.AddWithValue("@Bathrooms", property.Bathrooms);
                command.Parameters.AddWithValue("@Description", property.Description);
                command.Parameters.AddWithValue("@ListingDate", property.ListingDate);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void DisplaySuccessMessage()
        {
            toolStripStatusLabel1.Text = "Property updated successfully!";
            MessageBox.Show("Property updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CloseFormWithSuccess()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DisplayErrorMessage(string message)
        {
            MessageBox.Show($"Error updating property: {message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            toolStripStatusLabel1.Text = "Error updating property.";
        }

        private void DisplayValidationError()
        {
            MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            toolStripStatusLabel1.Text = "Missing 1 or more required fields!";
        }

        private void EditProperty_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            PopulateFields();
        }

        private void PopulateFields()
        {
            addressBox.Text = _propertyToEdit.Address;
            cityBox.Text = _propertyToEdit.City;
            stateBox.SelectedItem = _propertyToEdit.State;
            zipBox.Text = _propertyToEdit.ZipCode;
            priceBox.Text = _propertyToEdit.Price.ToString();
            typeBox.SelectedItem = _propertyToEdit.Type;
            bedroomNumber.Value = _propertyToEdit.Bedrooms;
            bathroomNumber.Value = _propertyToEdit.Bathrooms;
            descriptionBox.Text = _propertyToEdit.Description;
            dateBox.Value = _propertyToEdit.ListingDate;
        }
    }
}
