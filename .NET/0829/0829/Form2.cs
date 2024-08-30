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
    public partial class Form2 : Form
    {
        private double result = 0;
        private string operation = "";
        private bool isOperationPerformed = false;
        private List<string> history = new List<string>();

        public Form2()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0") || (isOperationPerformed))
                textBox1.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + button.Text;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            result = Double.Parse(textBox1.Text);
            isOperationPerformed = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("."))
                textBox1.Text = textBox1.Text + ".";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            result = 0;
            operation = "";
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            double secondOperand = Double.Parse(textBox1.Text);
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

            // Add the calculation to the history
            string calculation = $"{result} {operation} {secondOperand} = {calculationResult}";
            history.Insert(0, calculation);

            textBox1.Text = calculationResult.ToString();
            result = calculationResult;

            // Limit the history to 10 calculations
            if (history.Count > 10)
                history.RemoveAt(history.Count - 1);

            operation = "";
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            string historyText = string.Join(Environment.NewLine, history);
            MessageBox.Show(historyText, "Calculation History");
        }
    }
}
