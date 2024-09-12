using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _0829
{
    public partial class Form2 : Form
    {
        private double result = 0;
        private string operation = "";
        private bool isOperationPerformed = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || isOperationPerformed)
                textBox1.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            textBox1.Text += button.Text;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            result = double.Parse(textBox1.Text);
            isOperationPerformed = true;
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("."))
                textBox1.Text += ".";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            result = 0;
            operation = "";
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            double secondOperand = double.Parse(textBox1.Text);
            double calculationResult = 0;

            switch (operation)
            {
                case "+":
                    calculationResult = result + secondOperand;
                    break;
                case "-":
                    calculationResult = result - secondOperand;
                    break;
                case "*":
                    calculationResult = result * secondOperand;
                    break;
                case "/":
                    calculationResult = result / secondOperand;
                    break;
                default:
                    break;
            }

            string calculation = $"{result} {operation} {secondOperand} = {calculationResult}";
            SaveHistoryToDatabase(calculation);

            textBox1.Text = calculationResult.ToString();
            result = calculationResult;
            operation = "";
            LoadHistory();
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            ClearHistoryFromDatabase();
            LoadHistory();
        }

        private void ClearHistoryFromDatabase()
        {
            string connectionString = "Server=THEISLANDWIN\\SQLEXPRESS;Database=MAP;User Id=Avery;Password=Kgass12!@;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM History";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void SaveHistoryToDatabase(string calculation)
        {
            string connectionString = "Server=THEISLANDWIN\\SQLEXPRESS;Database=MAP;User Id=Avery;Password=Kgass12!@;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO History (historyString) VALUES (@Calculation)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Calculation", calculation);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private List<string> GetHistoryFromDatabase()
        {
            List<string> history = new List<string>();
            string connectionString = "Server=THEISLANDWIN\\SQLEXPRESS;Database=MAP;User Id=Avery;Password=Kgass12!@;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 10 historyString FROM History ORDER BY historyID DESC";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    history.Add(reader["historyString"].ToString());
                }
            }
            return history;
        }

        private void LoadHistory()
        {
            List<string> history = GetHistoryFromDatabase();
            listBox1.Items.Clear();
            for (int i = 0; i < history.Count; i++)
            {
                listBox1.Items.Add($"{i + 1}. {history[i]}");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }

        // Redundant button click methods
        private void button1_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button2_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button3_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button4_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button5_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button6_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button7_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button8_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button9_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button0_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void buttonDivide_Click(object sender, EventArgs e) => operator_Click(sender, e);
        private void buttonSubtract_Click(object sender, EventArgs e) => operator_Click(sender, e);
        private void buttonAdd_Click(object sender, EventArgs e) => operator_Click(sender, e);
        private void button10_Click(object sender, EventArgs e) => operator_Click(sender, e);
    }
}
