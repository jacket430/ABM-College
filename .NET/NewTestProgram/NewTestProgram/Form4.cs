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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            gradeDisplay1.Text = GetGrade("Science").ToString();
            gradeDisplay2.Text = GetGrade("Math").ToString();
            gradeDisplay3.Text = GetGrade("English").ToString();
            gradeDisplay4.Text = GetGrade("Social Studies").ToString();


        }

        private char GetGrade(string subject)
        {
            char grade = ' ';

            switch (subject)
            {
                case "Science":
                    grade = 'A';
                    break;
                case "Math":
                    grade = 'B';
                    break;
                case "English":
                    grade = 'C';
                    break;
                case "Social Studies":
                    grade = 'D';
                    break;
                default:
                    grade = 'N';
                    break;
            }

            return grade;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            int age = Convert.ToInt32(ageBox.Text);
            string grade = gradeBox.Text;
            string gender = genderBox.Text;

            identityDisplay(name, age, grade, gender);
        }

        private void identityDisplay(string name, int age, string grade, string gender)
        {
            string message = $"Hi! My name is {name}. I am {age} years old. I've received a grade of {grade}. My gender is {gender}.";
            MessageBox.Show(message);
        }

        private void palSubmitButton_Click(object sender, EventArgs e)
        {
            string input = palBox.Text;
            string[] palindromes = input.Split(',');

            bool allValid = true;
            List<int> invalidIndices = new List<int>();

            for (int i = 0; i < palindromes.Length; i++)
            {
                string palindrome = palindromes[i].Trim();
                bool isValid = CheckPalindrome(palindrome);

                if (!isValid)
                {
                    allValid = false;
                    invalidIndices.Add(i + 1);
                }
            }

            if (string.IsNullOrEmpty(input))
            {
                palLabel.Visible = false;
            }
            else
            {
                palLabel.Visible = true;

                if (allValid)
                {
                    palLabel.Text = "All palindromes are valid!";
                    palLabel.ForeColor = Color.Green;
                }
                else
                {
                    string invalidIndicesText = string.Join(" and ", invalidIndices);
                    string errorMessage = invalidIndices.Count > 1 ? $"Palindromes {invalidIndicesText} are invalid!" : $"Palindrome {invalidIndicesText} is invalid!";
                    palLabel.Text = errorMessage;
                    palLabel.ForeColor = Color.Red;
                }
            }
        }

        private bool CheckPalindrome(string input)
        {
            string reversedInput = new string(input.Reverse().ToArray());
            return input.Equals(reversedInput, StringComparison.OrdinalIgnoreCase);
        }
    }
}
 