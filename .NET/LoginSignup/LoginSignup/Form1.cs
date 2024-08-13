namespace LoginSignup
{
    public partial class Form1 : Form
    {
        public static Dictionary<string, string> userList = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            ComparePasswords();
        }

        private void ComparePasswords()
        {
            if (passBox.Text != confirmPassBox.Text)
            {
                passErrorLabel.Visible = true;
            }
            else
            {
                passErrorLabel.Visible = false;
                AddToUserList(emailBox.Text, passBox.Text);
            }
        }

        private void AddToUserList(string email, string password)
        {
            userList[email] = password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayUserList();
        }

        private void DisplayUserList()
        {
            string userListString = "";
            int entryNumber = 1;
            foreach (var user in userList)
            {
                userListString += $"Entry {entryNumber}:\nEmail: {user.Key}\nPassword: {user.Value}\n\n";
                entryNumber++;
            }
            MessageBox.Show(userListString, "User List");
        }

        private void openLoginForm_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
