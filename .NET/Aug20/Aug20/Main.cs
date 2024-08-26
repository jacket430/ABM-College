namespace Aug20
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openHomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
        }

        private void openAboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

        private void openMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
        }

        private void openContactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contact contactForm = new Contact();
            contactForm.Show();
        }
    }
}
