namespace NewTestProgram
{
    partial class Form2
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
            usernameLabel = new Label();
            passwordLabel = new Label();
            cityLabel = new Label();
            webserverLabel = new Label();
            roleLabel = new Label();
            departmentLabel = new Label();
            usernameBox = new TextBox();
            passwordBox = new TextBox();
            cityBox = new TextBox();
            webserverBox = new ComboBox();
            roleButton1 = new RadioButton();
            roleButton2 = new RadioButton();
            roleButton3 = new RadioButton();
            roleButton4 = new RadioButton();
            departmentCheck1 = new CheckBox();
            departmentCheck2 = new CheckBox();
            departmentCheck3 = new CheckBox();
            submitButton = new Button();
            resetButton = new Button();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(12, 9);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(63, 15);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(15, 50);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 1;
            passwordLabel.Text = "Password:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new Point(44, 89);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(31, 15);
            cityLabel.TabIndex = 2;
            cityLabel.Text = "City:";
            // 
            // webserverLabel
            // 
            webserverLabel.AutoSize = true;
            webserverLabel.Location = new Point(6, 129);
            webserverLabel.Name = "webserverLabel";
            webserverLabel.Size = new Size(69, 15);
            webserverLabel.TabIndex = 3;
            webserverLabel.Text = "Web Server:";
            // 
            // roleLabel
            // 
            roleLabel.AutoSize = true;
            roleLabel.Location = new Point(31, 203);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new Size(106, 15);
            roleLabel.TabIndex = 4;
            roleLabel.Text = "Please specify role:";
            // 
            // departmentLabel
            // 
            departmentLabel.AutoSize = true;
            departmentLabel.Location = new Point(64, 304);
            departmentLabel.Name = "departmentLabel";
            departmentLabel.Size = new Size(73, 15);
            departmentLabel.TabIndex = 5;
            departmentLabel.Text = "Department:";
            // 
            // usernameBox
            // 
            usernameBox.Location = new Point(81, 6);
            usernameBox.Name = "usernameBox";
            usernameBox.Size = new Size(165, 23);
            usernameBox.TabIndex = 6;
            // 
            // passwordBox
            // 
            passwordBox.Location = new Point(81, 47);
            passwordBox.Name = "passwordBox";
            passwordBox.Size = new Size(165, 23);
            passwordBox.TabIndex = 7;
            passwordBox.TextChanged += passwordBox_TextChanged;
            // 
            // cityBox
            // 
            cityBox.Location = new Point(81, 89);
            cityBox.Name = "cityBox";
            cityBox.Size = new Size(165, 23);
            cityBox.TabIndex = 8;
            // 
            // webserverBox
            // 
            webserverBox.FormattingEnabled = true;
            webserverBox.Items.AddRange(new object[] { "NA West", "NA East", "EU West", "EU East" });
            webserverBox.Location = new Point(81, 126);
            webserverBox.Name = "webserverBox";
            webserverBox.Size = new Size(165, 23);
            webserverBox.TabIndex = 9;
            // 
            // roleButton1
            // 
            roleButton1.AutoSize = true;
            roleButton1.Location = new Point(152, 167);
            roleButton1.Name = "roleButton1";
            roleButton1.Size = new Size(61, 19);
            roleButton1.TabIndex = 10;
            roleButton1.TabStop = true;
            roleButton1.Text = "Admin";
            roleButton1.UseVisualStyleBackColor = true;
            // 
            // roleButton2
            // 
            roleButton2.AutoSize = true;
            roleButton2.Location = new Point(152, 192);
            roleButton2.Name = "roleButton2";
            roleButton2.Size = new Size(71, 19);
            roleButton2.TabIndex = 11;
            roleButton2.TabStop = true;
            roleButton2.Text = "Engineer";
            roleButton2.UseVisualStyleBackColor = true;
            // 
            // roleButton3
            // 
            roleButton3.AutoSize = true;
            roleButton3.Location = new Point(152, 217);
            roleButton3.Name = "roleButton3";
            roleButton3.Size = new Size(72, 19);
            roleButton3.TabIndex = 12;
            roleButton3.TabStop = true;
            roleButton3.Text = "Manager";
            roleButton3.UseVisualStyleBackColor = true;
            // 
            // roleButton4
            // 
            roleButton4.AutoSize = true;
            roleButton4.Location = new Point(152, 242);
            roleButton4.Name = "roleButton4";
            roleButton4.Size = new Size(55, 19);
            roleButton4.TabIndex = 13;
            roleButton4.TabStop = true;
            roleButton4.Text = "Guest";
            roleButton4.UseVisualStyleBackColor = true;
            // 
            // departmentCheck1
            // 
            departmentCheck1.AutoSize = true;
            departmentCheck1.Location = new Point(152, 279);
            departmentCheck1.Name = "departmentCheck1";
            departmentCheck1.Size = new Size(49, 19);
            departmentCheck1.TabIndex = 14;
            departmentCheck1.Text = "Mail";
            departmentCheck1.UseVisualStyleBackColor = true;
            // 
            // departmentCheck2
            // 
            departmentCheck2.AutoSize = true;
            departmentCheck2.Location = new Point(152, 304);
            departmentCheck2.Name = "departmentCheck2";
            departmentCheck2.Size = new Size(62, 19);
            departmentCheck2.TabIndex = 15;
            departmentCheck2.Text = "Payroll";
            departmentCheck2.UseVisualStyleBackColor = true;
            // 
            // departmentCheck3
            // 
            departmentCheck3.AutoSize = true;
            departmentCheck3.Location = new Point(152, 329);
            departmentCheck3.Name = "departmentCheck3";
            departmentCheck3.Size = new Size(87, 19);
            departmentCheck3.TabIndex = 16;
            departmentCheck3.Text = "Self-Service";
            departmentCheck3.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(51, 380);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(75, 23);
            submitButton.TabIndex = 17;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(132, 380);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(75, 23);
            resetButton.TabIndex = 18;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(6, 347);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(252, 30);
            errorLabel.TabIndex = 19;
            errorLabel.Text = "Make sure you have entered a password!";
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            errorLabel.Visible = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(260, 413);
            Controls.Add(errorLabel);
            Controls.Add(resetButton);
            Controls.Add(submitButton);
            Controls.Add(departmentCheck3);
            Controls.Add(departmentCheck2);
            Controls.Add(departmentCheck1);
            Controls.Add(roleButton4);
            Controls.Add(roleButton3);
            Controls.Add(roleButton2);
            Controls.Add(roleButton1);
            Controls.Add(webserverBox);
            Controls.Add(cityBox);
            Controls.Add(passwordBox);
            Controls.Add(usernameBox);
            Controls.Add(departmentLabel);
            Controls.Add(roleLabel);
            Controls.Add(webserverLabel);
            Controls.Add(cityLabel);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Name = "Form2";
            Text = "Login Verification";
            TextChanged += passwordBox_TextChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label usernameLabel;
        private Label passwordLabel;
        private Label cityLabel;
        private Label webserverLabel;
        private Label roleLabel;
        private Label departmentLabel;
        private TextBox usernameBox;
        private TextBox passwordBox;
        private TextBox cityBox;
        private ComboBox webserverBox;
        private RadioButton roleButton1;
        private RadioButton roleButton2;
        private RadioButton roleButton3;
        private RadioButton roleButton4;
        private CheckBox departmentCheck1;
        private CheckBox departmentCheck2;
        private CheckBox departmentCheck3;
        private Button submitButton;
        private Button resetButton;
        private Label errorLabel;
    }
}