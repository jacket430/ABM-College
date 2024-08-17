using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatePickerCalc
{
    public partial class Form2 : Form
    {
        private Dictionary<string, DateTime>? concerts;
        private bool startDateSet;
        private bool endDateSet;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitializeConcerts();
            PopulateListBox();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " ";

            startDateSet = false;
            endDateSet = false;

            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;

            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel1.Image = null;
        }

        private void InitializeConcerts()
        {
            concerts = new Dictionary<string, DateTime>
                {
                    { "Less Than Jake", new DateTime(2025, 1, 15) },
                    { "Foo Fighters", new DateTime(2024, 9, 27) },
                    { "Alkaline Trio", new DateTime(2024, 10, 1) },
                    { "Silk Sonic", new DateTime(2024, 11, 10) },
                    { "Boston", new DateTime(2024, 8, 20) },
                    { "Green Day", new DateTime(2024, 8, 25) },
                    { "Red Hot Chili Peppers", new DateTime(2024, 10, 5) },
                    { "Nirvana", new DateTime(2024, 11, 15) },
                    { "The Rolling Stones", new DateTime(2025, 1, 25) },
                    { "Queen", new DateTime(2025, 3, 10) }
                };
        }

        private void PopulateListBox()
        {
            listBox1.Items.Clear();

            if (concerts != null)
            {
                foreach (var concert in concerts)
                {
                    listBox1.Items.Add($"{concert.Key} - {concert.Value.ToShortDateString()}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel1.Image = null;

            if (!startDateSet && !endDateSet)
            {
                return;
            }

            if (!startDateSet || !endDateSet)
            {
                toolStripStatusLabel1.Text = "Please select both start and end dates first!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Image = SystemIcons.Error.ToBitmap();
                return;
            }

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            listBox1.Items.Clear();

            if (concerts != null)
            {
                foreach (var concert in concerts)
                {
                    if (concert.Value >= startDate && concert.Value <= endDate)
                    {
                        listBox1.Items.Add($"{concert.Key} - {concert.Value.ToShortDateString()}");
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object? sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "d MMMM yyyy";
            startDateSet = true;
        }

        private void dateTimePicker2_ValueChanged(object? sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "d MMMM yyyy";
            endDateSet = true;
        }
    }
}
