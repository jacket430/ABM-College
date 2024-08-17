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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            UpdateButtonStates();
        }

        // Move right
        private void button1_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(listBox1, listBox2);
        }

        // Move all to the right
        private void button2_Click(object sender, EventArgs e)
        {
            MoveAllItems(listBox1, listBox2);
        }

        // Move all to the left
        private void button3_Click(object sender, EventArgs e)
        {
            MoveAllItems(listBox2, listBox1);
        }

        // Move selected to the left
        private void button4_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(listBox2, listBox1);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += ListBox_SelectedIndexChanged;

            UpdateButtonStates();
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void MoveSelectedItems(ListBox source, ListBox destination)
        {
            ListBox.SelectedObjectCollection selectedItems = source.SelectedItems;
            List<object> itemsToMove = new List<object>();

            foreach (var item in selectedItems)
            {
                itemsToMove.Add(item);
            }

            foreach (var item in itemsToMove)
            {
                source.Items.Remove(item);
                destination.Items.Add(item);
            }

            SortListBox(destination);
            UpdateButtonStates();
        }

        private void MoveAllItems(ListBox source, ListBox destination)
        {
            List<object> itemsToMove = new List<object>();

            foreach (var item in source.Items)
            {
                itemsToMove.Add(item);
            }

            foreach (var item in itemsToMove)
            {
                source.Items.Remove(item);
                destination.Items.Add(item);
            }

            SortListBox(destination);
            UpdateButtonStates();
        }

        private void SortListBox(ListBox listBox)
        {
            List<object> sortedItems = listBox.Items.Cast<object>().OrderBy(item => item.ToString()).ToList();
            listBox.Items.Clear();
            foreach (var item in sortedItems)
            {
                listBox.Items.Add(item);
            }
        }

        private void UpdateButtonStates()
        {
            button1.Enabled = listBox1.SelectedItems.Count > 0;
            button2.Enabled = listBox1.Items.Count > 0;
            button3.Enabled = listBox2.Items.Count > 0;
            button4.Enabled = listBox2.SelectedItems.Count > 0;
        }
    }
}
