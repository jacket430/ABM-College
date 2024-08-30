using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0829
{
    public partial class Populate : Form
    {
        public Populate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            dbHelper.AddHardCodedEntries();
            MessageBox.Show("10 Entries have been added");
        }
    }
}
