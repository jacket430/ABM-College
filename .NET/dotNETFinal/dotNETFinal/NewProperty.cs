using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dotNETFinal
{
    public partial class NewProperty : Form
    {
        public NewProperty()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            try
            {
                var property = new Property
                {
                    Address = addressBox.Text.Trim(),
                    City = cityBox.Text.Trim(),
                    State = stateBox.SelectedItem?.ToString() ?? string.Empty,
                    ZipCode = zipBox.Text.Trim(),
                    Price = decimal.TryParse(priceBox.Text, out decimal price) ? price : 0m,
                    Type = typeBox.SelectedItem?.ToString() ?? string.Empty,
                    Bedrooms = (int)bedroomNumber.Value,
                    Bathrooms = (int)bathroomNumber.Value,
                    Description = descriptionBox.Text.Trim(),
                    ListingDate = dateBox.Value
                };

                if (ValidateProperty(property))
                {
                    InsertProperty(property);
                    toolStripStatusLabel1.Text = "Property added successfully!";
                    MessageBox.Show("Property added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding property: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Error adding property.";
            }
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
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolStripStatusLabel1.Text = "Missing 1 or more required fields!";
                return false;
            }
            return true;
        }

        private void InsertProperty(Property property)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlString"].ConnectionString;
            const string query = @"INSERT INTO Properties (Address, City, State, ZipCode, Price, Type, Bedrooms, Bathrooms, Description, ListingDate) 
                 VALUES (@Address, @City, @State, @ZipCode, @Price, @Type, @Bedrooms, @Bathrooms, @Description, @ListingDate)";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Address", property.Address);
                command.Parameters.AddWithValue("@City", property.City);
                command.Parameters.AddWithValue("@State", property.State);
                command.Parameters.AddWithValue("@ZipCode", property.ZipCode);
                command.Parameters.AddWithValue("@Price", property.Price);
                command.Parameters.AddWithValue("@Type", property.Type);
                command.Parameters.AddWithValue("@Bedrooms", property.Bedrooms);
                command.Parameters.AddWithValue("@Bathrooms", property.Bathrooms);
                command.Parameters.AddWithValue("@Description", (object)property.Description ?? DBNull.Value);
                command.Parameters.AddWithValue("@ListingDate", property.ListingDate);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void NewProperty_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}
