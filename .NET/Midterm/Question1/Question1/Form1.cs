namespace Question1
{
    public partial class Form1 : Form
    {
        // List to store registered user information
        private List<User> registeredUsers = new List<User>();

        public Form1()
        {
            InitializeComponent();
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            // Check if the user has already registered
            if (registeredUsers.Any(u => u.Username == userRegBox.Text))
            {
                // Update the status strip with a message indicating that the user has already registered
                toolStripStatusLabel1.Text = "Account already registered. Please login with your registered information.";
            }
            else
            {
                // Create a new user object with the registration information
                User newUser = new User
                {
                    Email = emailRegBox.Text,
                    Username = userRegBox.Text,
                    Password = passRegBox.Text
                };

                // Add the new user to the list of registered users
                registeredUsers.Add(newUser);

                // Update the status strip with a registration success message
                toolStripStatusLabel1.Text = "User registered successfully!";
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Find the user with the entered username and password
            User loginUser = registeredUsers.FirstOrDefault(u => u.Username == userLoginBox.Text && u.Password == passLoginBox.Text)!;

            if (loginUser != null)
            {
                // Update the status strip with a login success message
                toolStripStatusLabel1.Text = "Login successful!";

                // Open Form2 and pass the logged-in user
                Form2 form2 = new Form2(loginUser);
                form2.Show();

                // Hide Form1 instead of closing it
                this.Hide();
            }
            else
            {
                // Update the status strip with an invalid login message
                toolStripStatusLabel1.Text = "Invalid username or password.";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open Form3
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class User
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
