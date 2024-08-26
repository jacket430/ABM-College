using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aug20
{
    public partial class Home : Form
    {
        private decimal subtotal = 0m;

        public Home()
        {
            InitializeComponent();
            UpdateReceipt();
        }

        private void AddToCart(decimal price)
        {
            subtotal += price;
            UpdateReceipt();
        }

        private void UpdateReceipt()
        {
            decimal gst = subtotal * 0.05m;
            decimal total = subtotal + gst;
            richTextBox1.Text = $"Subtotal: {subtotal:F2}\nGST: {gst:F2}\nTotal: {total:F2}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddToCart(2.99m);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddToCart(3.89m);
        }

        private void resetTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subtotal = 0m;
            UpdateReceipt();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddToCart(4.19m);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            AddToCart(1.99m);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AddToCart(5.79m);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            AddToCart(1.99m);
        }
    }
}
