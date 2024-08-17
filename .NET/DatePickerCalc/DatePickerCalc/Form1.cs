namespace DatePickerCalc
{
    public partial class Form1 : Form
    {
        private bool DateSet; // Global bool variable

        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "d MMMM yyyy";

            DateSet = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!DateSet)
            {
                datetimeLabel.Visible = true;
                datetimeLabel.ForeColor = Color.Red;
                datetimeLabel.Text = "Please select a date first!";
            }
            else
            {
                UpdateDateTimeLabel();
            }
        }

        private void UpdateDateTimeLabel()
        {
            datetimeLabel.Visible = true;
            DateTime selectedDate = dateTimePicker1.Value;
            string formattedDate = selectedDate.ToString("d MMMM yyyy h:mm:ss tt");
            datetimeLabel.ForeColor = Color.Black;
            datetimeLabel.Text = formattedDate;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " ";

            DateSet = false;
        }
    }
}
