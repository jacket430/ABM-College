namespace NewTestProgram
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            checkBox1 = new CheckBox();
            radioButton1 = new RadioButton();
            maleBox = new CheckBox();
            femaleBox = new CheckBox();
            genderLabel = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(352, 231);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(341, 187);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(352, 130);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(347, 155);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(94, 19);
            radioButton1.TabIndex = 3;
            radioButton1.TabStop = true;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // maleBox
            // 
            maleBox.AutoSize = true;
            maleBox.Location = new Point(109, 277);
            maleBox.Name = "maleBox";
            maleBox.Size = new Size(52, 19);
            maleBox.TabIndex = 4;
            maleBox.Text = "Male";
            maleBox.UseVisualStyleBackColor = true;
            maleBox.CheckedChanged += maleBox_CheckedChanged;
            // 
            // femaleBox
            // 
            femaleBox.AutoSize = true;
            femaleBox.Location = new Point(109, 302);
            femaleBox.Name = "femaleBox";
            femaleBox.Size = new Size(64, 19);
            femaleBox.TabIndex = 5;
            femaleBox.Text = "Female";
            femaleBox.UseVisualStyleBackColor = true;
            femaleBox.CheckedChanged += femaleBox_CheckedChanged;
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            genderLabel.Location = new Point(109, 324);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(161, 21);
            genderLabel.TabIndex = 6;
            genderLabel.Text = "Waiting for selection...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(genderLabel);
            Controls.Add(femaleBox);
            Controls.Add(maleBox);
            Controls.Add(radioButton1);
            Controls.Add(checkBox1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            Move += Form1_Move;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private RadioButton radioButton1;
        private CheckBox maleBox;
        private CheckBox femaleBox;
        private Label genderLabel;
    }
}
