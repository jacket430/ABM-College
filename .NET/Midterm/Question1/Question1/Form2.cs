using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question1
{
    public partial class Form2 : Form
    {
        private Dictionary<string, decimal> products = new Dictionary<string, decimal>
            {
                { "Yeyian Yumi Gaming PC", 1099.99m },
                { "Hasee Z8 Gaming Laptop", 1099.99m },
                { "Gigabyte GeForce 4070", 749.99m },
                { "WD Blue M.2 1TB SSD", 89.97m },
                { "AMD Ryzen 5 7600", 269.00m },
                { "NZXT Kraken RGB 280mm", 189.99m },
                { "EVGA 700W PSU", 84.99m },
                { "Intel Core i5-12600KF", 219.99m },
                { "Yeyian PHOENIX GLASS", 2299.97m },
                { "KingSpec 2TB NVMe", 203.99m },
                { "LIAN LI 001 EVO", 189.99m },
                { "PS5 Slim Marvel Bundle", 1011.99m },
                { "SAMA SM68 Wireless", 35.99m },
                { "GIGABYTE Z790", 283.99m },
                { "ASRock B550 Phantom", 699.99m },
                { "SAMA 6CF1201", 15.99m },
                { "ASUS TUF B760-PLUS", 188.99m },
                { "Astro Bot", 79.99m },
                { "Mario Party Jamboree", 79.99m },
                { "COD Black Ops 6", 89.99m },
                { "Zelda: Echoes of Wisdom", 79.99m },
                { "Mario and Luigi: Brothership", 79.99m },
                { "Star Wars: Outlaws", 79.99m },
                { "Silent Hill 2", 89.99m },
                { "Nocturnal", 49.99m },
                { "Little Nightmares III", 54.99m },
                { "Titan Quest II", 69.99m },
                { "Orange Season", 39.99m },
                { "Ravenswatch", 49.99m },
                { "Indiana Jones", 89.99m },
                { "Petit Island", 79.99m },
                { "Goblin Slayer", 69.99m },
                { "Undisputed", 79.99m },
                { "Battle Of Rebels", 49.99m },
                { "OnePlus Nord N30", 379.99m },
                { "Google Pixel 7", 549.99m },
                { "Samsung Galaxy A15", 269.98m },
                { "iPhone 15", 1129.00m },
                { "ZTE Blade A34", 149.00m },
                { "Xiaomi Redmi K40", 233.24m },
                { "Oscal Tiger 12", 244.98m },
                { "Motorola Moto G Stylus", 176.93m }
            };

        private List<string> cart = new List<string>();
        private decimal total = 0m;
        private User loggedInUser;

        public Form2(User user)
        {
            InitializeComponent();
            InitializeListView();
            loggedInUser = user;
        }

        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.LabelEdit = false;
            listView1.AllowColumnReorder = false;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Product Name", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Price", 75, HorizontalAlignment.Left);
        }

        private void UpdateCartList()
        {
            listView1.Items.Clear();
            foreach (string product in cart)
            {
                ListViewItem item = new ListViewItem(product);
                item.SubItems.Add(products[product].ToString("C"));
                listView1.Items.Add(item);
            }
        }

        private void UpdateTotal()
        {
            decimal discountedTotal = total - (total * currentDiscountPercentage);
            textBox1.Text = $"Total: {discountedTotal:C} (Discount: {currentDiscountPercentage:P0})";
        }

        private void AddToCart(string product)
        {
            if (products.ContainsKey(product))
            {
                cart.Add(product);
                total += products[product];
                UpdateCartList();
                UpdateTotal();
            }
        }

        private void RemoveFromCart(string product)
        {
            if (cart.Contains(product))
            {
                cart.Remove(product);
                total -= products[product];
                UpdateCartList();
                UpdateTotal();
            }
        }

        private decimal currentDiscountPercentage = 0m;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string? selectedDiscount = comboBox1.SelectedItem.ToString();
                if (selectedDiscount != null)
                {
                    try
                    {
                        currentDiscountPercentage = decimal.Parse(selectedDiscount.TrimEnd('%')) / 100;
                        UpdateTotal();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Invalid discount format. Please select a valid discount.");
                    }
                }
            }
        }

        private void ApplyDiscount(decimal discountPercentage)
        {
            decimal discountedTotal = total - (total * discountPercentage);
            textBox1.Text = $"Total: {discountedTotal:C} (Discount: {discountPercentage:P0})";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddToCart("Yeyian Yumi Gaming PC");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Yeyian Yumi Gaming PC");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddToCart("Hasee Z8 Gaming Laptop");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Hasee Z8 Gaming Laptop");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddToCart("Gigabyte GeForce 4070");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Gigabyte GeForce 4070");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddToCart("WD Blue M.2 1TB SSD");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RemoveFromCart("WD Blue M.2 1TB SSD");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            RemoveFromCart("AMD Ryzen 5 7600");
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            AddToCart("AMD Ryzen 5 7600");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentCategory == "Computers")
            {
                panel1.Visible = false;
                panel2.Visible = true;
                button2.Enabled = false;
                button1.Enabled = true;
            }

            if (currentCategory == "Video Games")
            {
                panel3.Visible = false;
                panel4.Visible = true;
                button2.Enabled = false;
                button1.Enabled = true;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AddToCart("NZXT Kraken RGB 280mm");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            RemoveFromCart("NZXT Kraken RGB 280mm");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            AddToCart("EVGA 700W PSU");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            RemoveFromCart("EVGA 700W PSU");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            AddToCart("Intel Core i5-12600KF");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Intel Core i5-12600KF");
        }

        private void button35_Click(object sender, EventArgs e)
        {
            AddToCart("Yeyian PHOENIX GLASS");
        }

        private void button34_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Yeyian PHOENIX GLASS");
        }

        private void button33_Click(object sender, EventArgs e)
        {
            AddToCart("KingSpec 2TB NVMe");
        }

        private void button32_Click(object sender, EventArgs e)
        {
            RemoveFromCart("KingSpec 2TB NVMe");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            SetCategoryToComputers();
        }

        private string currentCategory = "";

        private void SetCategoryToComputers()
        {
            currentCategory = "Computers";
            HideAllPanels();
            panel1.Visible = true;
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            currentCategory = "Computers";
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentCategory == "Computers")
            {
                panel1.Visible = true;
                panel2.Visible = false;
                button2.Enabled = true;
                button1.Enabled = false;
            }

            if (currentCategory == "Video Games")
            {
                panel3.Visible = true;
                panel4.Visible = false;
                button2.Enabled = true;
                button1.Enabled = false;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            AddToCart("LIAN LI 001 EVO");
        }

        private void button30_Click(object sender, EventArgs e)
        {
            RemoveFromCart("LIAN LI 001 EVO");
        }

        private void button29_Click(object sender, EventArgs e)
        {
            AddToCart("ASUS TUF B760-PLUS");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            RemoveFromCart("ASUS TUF B760-PLUS");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            AddToCart("SAMA SM68 Wireless");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            RemoveFromCart("SAMA SM68 Wireless");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            AddToCart("GIGABYTE Z790");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            RemoveFromCart("GIGABYTE Z790");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            AddToCart("ASRock B550 Phantom");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            RemoveFromCart("ASRock B550 Phantom");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            AddToCart("SAMA 6CF1201");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            RemoveFromCart("SAMA 6CF1201");
        }

        private void button37_Click(object sender, EventArgs e)
        {

        }
        private void SetCategoryToVideoGames()
        {
            currentCategory = "Video Games";
            HideAllPanels();
            panel3.Visible = true;
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button37_Click_1(object sender, EventArgs e)
        {
            SetCategoryToVideoGames();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            AddToCart("Astro Bot");
        }

        private void button53_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Astro Bot");
        }

        private void button52_Click(object sender, EventArgs e)
        {
            AddToCart("Mario Party Jamboree");
        }

        private void button51_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Mario Party Jamboree");
        }

        private void button50_Click(object sender, EventArgs e)
        {
            AddToCart("COD Black Ops 6");
        }

        private void button49_Click(object sender, EventArgs e)
        {
            RemoveFromCart("COD Black Ops 6");
        }

        private void button48_Click(object sender, EventArgs e)
        {
            AddToCart("Zelda: Echoes of Wisdom");
        }

        private void button47_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Zelda: Echoes of Wisdom");
        }

        private void button46_Click(object sender, EventArgs e)
        {
            AddToCart("Star Wars: Outlaws");
        }

        private void button45_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Star Wars: Outlaws");
        }

        private void button44_Click(object sender, EventArgs e)
        {
            AddToCart("Silent Hill 2");
        }

        private void button43_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Silent Hill 2");
        }

        private void button42_Click(object sender, EventArgs e)
        {
            AddToCart("Nocturnal");
        }

        private void button41_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Nocturnal");
        }

        private void button40_Click(object sender, EventArgs e)
        {
            AddToCart("Little Nightmares III");
        }

        private void button39_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Little Nightmares III");
        }
        private void HideAllPanels()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void button70_Click(object sender, EventArgs e)
        {
            AddToCart("Titan Quest II");
        }

        private void button69_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Titan Quest II");
        }

        private void button68_Click(object sender, EventArgs e)
        {
            AddToCart("Orange Season");
        }

        private void button67_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Orange Season");
        }

        private void button66_Click(object sender, EventArgs e)
        {
            AddToCart("Ravenswatch");
        }

        private void button65_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Ravenswatch");
        }

        private void button64_Click(object sender, EventArgs e)
        {
            AddToCart("Indiana Jones");
        }

        private void button63_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Indiana Jones");
        }

        private void button62_Click(object sender, EventArgs e)
        {
            AddToCart("Petit Island");
        }

        private void button61_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Petit Island");
        }

        private void button60_Click(object sender, EventArgs e)
        {
            AddToCart("Goblin Slayer");
        }

        private void button59_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Goblin Slayer");
        }

        private void button58_Click(object sender, EventArgs e)
        {
            AddToCart("Undisputed");
        }

        private void button57_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Undisputed");
        }

        private void button56_Click(object sender, EventArgs e)
        {
            AddToCart("Battle Of Rebels");
        }

        private void button55_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Battle Of Rebels");
        }

        private void button86_Click(object sender, EventArgs e)
        {
            AddToCart("OnePlus Nord N30");
        }

        private void button85_Click(object sender, EventArgs e)
        {
            RemoveFromCart("OnePlus Nord N30");
        }

        private void button84_Click(object sender, EventArgs e)
        {
            AddToCart("Google Pixel 7");
        }

        private void button83_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Google Pixel 7");
        }

        private void button82_Click(object sender, EventArgs e)
        {
            AddToCart("Samsung Galaxy A15");
        }

        private void button81_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Samsung Galaxy A15");
        }

        private void button80_Click(object sender, EventArgs e)
        {
            AddToCart("iPhone 15");
        }

        private void button79_Click(object sender, EventArgs e)
        {
            RemoveFromCart("iPhone 15");
        }

        private void button78_Click(object sender, EventArgs e)
        {
            AddToCart("ZTE Blade A34");
        }

        private void button77_Click(object sender, EventArgs e)
        {
            RemoveFromCart("ZTE Blade A34");
        }

        private void button76_Click(object sender, EventArgs e)
        {
            AddToCart("Xiaomi Redmi K40");
        }

        private void button75_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Xiaomi Redmi K40");
        }

        private void button74_Click(object sender, EventArgs e)
        {
            AddToCart("Oscal Tiger 12");
        }

        private void button73_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Oscal Tiger 12");
        }

        private void button72_Click(object sender, EventArgs e)
        {
            AddToCart("Motorola Moto G Stylus");
        }

        private void button71_Click(object sender, EventArgs e)
        {
            RemoveFromCart("Motorola Moto G Stylus");
        }

        private void button36_Click(object sender, EventArgs e)
        {
            string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            string currentTime = DateTime.Now.ToString("hh:mm tt");

            string customerEmail = loggedInUser.Email ?? "example@example.com";

            StringBuilder receiptContent = new StringBuilder();
            receiptContent.AppendLine("------------------------------");
            receiptContent.AppendLine("        Averyzon Receipt       ");
            receiptContent.AppendLine("------------------------------");
            receiptContent.AppendLine($"Date: {currentDate}");
            receiptContent.AppendLine($"Time: {currentTime}");
            receiptContent.AppendLine($"Customer Email: {customerEmail}");
            receiptContent.AppendLine("------------------------------");
            receiptContent.AppendLine("Items Purchased:");
            receiptContent.AppendLine("------------------------------");

            foreach (string product in cart)
            {
                decimal price = products[product];
                receiptContent.AppendLine($"{product,-30} {price:C}");
            }

            receiptContent.AppendLine("------------------------------");
            receiptContent.AppendLine($"Total: {total:C}");
            receiptContent.AppendLine("------------------------------");

            MessageBox.Show(receiptContent.ToString(), "Receipt");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button38_Click(object sender, EventArgs e)
        {
            cart.Clear();
            total = 0m;
            UpdateCartList();

            currentDiscountPercentage = 0m;
            UpdateTotal();

            comboBox1.Text = "Discount";
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}