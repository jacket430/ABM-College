using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTestProgram
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string name = VerifyName();
            nameLabel.Text = name;
        }

        private string VerifyName()
        {
            return "Avery Hogan";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string phoneNumber = phoneBox.Text;
            bool isValid = VerifyPhoneNumber(phoneNumber);

            if (isValid)
            {
                verificationLabel.Text = "Phone number is valid!";
                verificationLabel.ForeColor = Color.Green;
            }
            else
            {
                verificationLabel.Text = "Phone number is invalid!";
                verificationLabel.ForeColor = Color.Red;
            }
        }

        private bool VerifyPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 10)
            {
                return false;
            }

            foreach (char c in phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
