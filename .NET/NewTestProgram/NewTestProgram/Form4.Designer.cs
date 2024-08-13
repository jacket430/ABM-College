namespace NewTestProgram
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gradeDisplay1 = new Label();
            subjectLabel1 = new Label();
            subjectLabel2 = new Label();
            subjectLabel3 = new Label();
            subjectLabel4 = new Label();
            gradeDisplay2 = new Label();
            gradeDisplay3 = new Label();
            gradeDisplay4 = new Label();
            nameLabel = new Label();
            nameBox = new TextBox();
            ageBox = new TextBox();
            ageLabel = new Label();
            genderLabel = new Label();
            gradeLabel = new Label();
            gradeBox = new TextBox();
            submitButton = new Button();
            genderBox = new ComboBox();
            palBox = new TextBox();
            palSubmitButton = new Button();
            palLabel = new Label();
            SuspendLayout();
            // 
            // gradeDisplay1
            // 
            gradeDisplay1.AutoSize = true;
            gradeDisplay1.Location = new Point(123, 17);
            gradeDisplay1.Name = "gradeDisplay1";
            gradeDisplay1.Size = new Size(13, 15);
            gradeDisplay1.TabIndex = 0;
            gradeDisplay1.Text = "F";
            // 
            // subjectLabel1
            // 
            subjectLabel1.AutoSize = true;
            subjectLabel1.Location = new Point(21, 17);
            subjectLabel1.Name = "subjectLabel1";
            subjectLabel1.Size = new Size(50, 15);
            subjectLabel1.TabIndex = 1;
            subjectLabel1.Text = "Science:";
            // 
            // subjectLabel2
            // 
            subjectLabel2.AutoSize = true;
            subjectLabel2.Location = new Point(21, 42);
            subjectLabel2.Name = "subjectLabel2";
            subjectLabel2.Size = new Size(38, 15);
            subjectLabel2.TabIndex = 2;
            subjectLabel2.Text = "Math:";
            // 
            // subjectLabel3
            // 
            subjectLabel3.AutoSize = true;
            subjectLabel3.Location = new Point(21, 66);
            subjectLabel3.Name = "subjectLabel3";
            subjectLabel3.Size = new Size(48, 15);
            subjectLabel3.TabIndex = 3;
            subjectLabel3.Text = "English:";
            // 
            // subjectLabel4
            // 
            subjectLabel4.AutoSize = true;
            subjectLabel4.Location = new Point(21, 91);
            subjectLabel4.Name = "subjectLabel4";
            subjectLabel4.Size = new Size(82, 15);
            subjectLabel4.TabIndex = 4;
            subjectLabel4.Text = "Social Studies:";
            // 
            // gradeDisplay2
            // 
            gradeDisplay2.AutoSize = true;
            gradeDisplay2.Location = new Point(123, 42);
            gradeDisplay2.Name = "gradeDisplay2";
            gradeDisplay2.Size = new Size(13, 15);
            gradeDisplay2.TabIndex = 5;
            gradeDisplay2.Text = "F";
            // 
            // gradeDisplay3
            // 
            gradeDisplay3.AutoSize = true;
            gradeDisplay3.Location = new Point(123, 66);
            gradeDisplay3.Name = "gradeDisplay3";
            gradeDisplay3.Size = new Size(13, 15);
            gradeDisplay3.TabIndex = 6;
            gradeDisplay3.Text = "F";
            // 
            // gradeDisplay4
            // 
            gradeDisplay4.AutoSize = true;
            gradeDisplay4.Location = new Point(123, 91);
            gradeDisplay4.Name = "gradeDisplay4";
            gradeDisplay4.Size = new Size(13, 15);
            gradeDisplay4.TabIndex = 7;
            gradeDisplay4.Text = "F";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(21, 150);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(42, 15);
            nameLabel.TabIndex = 8;
            nameLabel.Text = "Name:";
            // 
            // nameBox
            // 
            nameBox.Location = new Point(69, 147);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(126, 23);
            nameBox.TabIndex = 9;
            // 
            // ageBox
            // 
            ageBox.Location = new Point(69, 176);
            ageBox.Name = "ageBox";
            ageBox.Size = new Size(126, 23);
            ageBox.TabIndex = 10;
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new Point(28, 179);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(31, 15);
            ageLabel.TabIndex = 11;
            ageLabel.Text = "Age:";
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new Point(11, 237);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(48, 15);
            genderLabel.TabIndex = 12;
            genderLabel.Text = "Gender:";
            // 
            // gradeLabel
            // 
            gradeLabel.AutoSize = true;
            gradeLabel.Location = new Point(18, 208);
            gradeLabel.Name = "gradeLabel";
            gradeLabel.Size = new Size(41, 15);
            gradeLabel.TabIndex = 13;
            gradeLabel.Text = "Grade:";
            // 
            // gradeBox
            // 
            gradeBox.Location = new Point(69, 205);
            gradeBox.Name = "gradeBox";
            gradeBox.Size = new Size(126, 23);
            gradeBox.TabIndex = 14;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(43, 263);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(126, 23);
            submitButton.TabIndex = 16;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // genderBox
            // 
            genderBox.FormattingEnabled = true;
            genderBox.Items.AddRange(new object[] { "Female", "Male" });
            genderBox.Location = new Point(69, 234);
            genderBox.Name = "genderBox";
            genderBox.Size = new Size(126, 23);
            genderBox.TabIndex = 17;
            // 
            // palBox
            // 
            palBox.Location = new Point(12, 335);
            palBox.Name = "palBox";
            palBox.Size = new Size(184, 23);
            palBox.TabIndex = 18;
            // 
            // palSubmitButton
            // 
            palSubmitButton.Location = new Point(55, 364);
            palSubmitButton.Name = "palSubmitButton";
            palSubmitButton.Size = new Size(92, 23);
            palSubmitButton.TabIndex = 19;
            palSubmitButton.Text = "Check";
            palSubmitButton.UseVisualStyleBackColor = true;
            palSubmitButton.Click += palSubmitButton_Click;
            // 
            // palLabel
            // 
            palLabel.Location = new Point(12, 308);
            palLabel.Name = "palLabel";
            palLabel.Size = new Size(183, 24);
            palLabel.TabIndex = 20;
            palLabel.Text = "Pal Label";
            palLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(palLabel);
            Controls.Add(palSubmitButton);
            Controls.Add(palBox);
            Controls.Add(genderBox);
            Controls.Add(submitButton);
            Controls.Add(gradeBox);
            Controls.Add(gradeLabel);
            Controls.Add(genderLabel);
            Controls.Add(ageLabel);
            Controls.Add(ageBox);
            Controls.Add(nameBox);
            Controls.Add(nameLabel);
            Controls.Add(gradeDisplay4);
            Controls.Add(gradeDisplay3);
            Controls.Add(gradeDisplay2);
            Controls.Add(subjectLabel4);
            Controls.Add(subjectLabel3);
            Controls.Add(subjectLabel2);
            Controls.Add(subjectLabel1);
            Controls.Add(gradeDisplay1);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label gradeDisplay1;
        private Label subjectLabel1;
        private Label subjectLabel2;
        private Label subjectLabel3;
        private Label subjectLabel4;
        private Label gradeDisplay2;
        private Label gradeDisplay3;
        private Label gradeDisplay4;
        private Label nameLabel;
        private TextBox nameBox;
        private TextBox ageBox;
        private Label ageLabel;
        private Label genderLabel;
        private Label gradeLabel;
        private TextBox gradeBox;
        private Button submitButton;
        private ComboBox genderBox;
        private TextBox palBox;
        private Button palSubmitButton;
        private Label palLabel;
    }
}