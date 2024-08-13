namespace LoginSignup
{
    partial class Form3
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
            loginButton = new Button();
            emailLabel = new Label();
            emailBox = new TextBox();
            forgotPasswordLabel = new Label();
            passBox = new TextBox();
            passLabel = new Label();
            changeButton = new Button();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.Location = new Point(76, 83);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 10;
            loginButton.Text = "Submit";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(31, 15);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(39, 15);
            emailLabel.TabIndex = 8;
            emailLabel.Text = "Email:";
            // 
            // emailBox
            // 
            emailBox.Location = new Point(76, 12);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(133, 23);
            emailBox.TabIndex = 6;
            // 
            // forgotPasswordLabel
            // 
            forgotPasswordLabel.ForeColor = Color.Red;
            forgotPasswordLabel.Location = new Point(0, 65);
            forgotPasswordLabel.Name = "forgotPasswordLabel";
            forgotPasswordLabel.Size = new Size(224, 15);
            forgotPasswordLabel.TabIndex = 11;
            forgotPasswordLabel.Text = "Email not found!";
            forgotPasswordLabel.TextAlign = ContentAlignment.MiddleCenter;
            forgotPasswordLabel.Visible = false;
            // 
            // passBox
            // 
            passBox.Location = new Point(76, 39);
            passBox.Name = "passBox";
            passBox.Size = new Size(133, 23);
            passBox.TabIndex = 12;
            passBox.Visible = false;
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Location = new Point(10, 42);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(60, 15);
            passLabel.TabIndex = 13;
            passLabel.Text = "Password:";
            passLabel.Visible = false;
            // 
            // changeButton
            // 
            changeButton.Location = new Point(76, 83);
            changeButton.Name = "changeButton";
            changeButton.Size = new Size(75, 23);
            changeButton.TabIndex = 14;
            changeButton.Text = "Change";
            changeButton.UseVisualStyleBackColor = true;
            changeButton.Visible = false;
            changeButton.Click += changeButton_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(224, 111);
            Controls.Add(changeButton);
            Controls.Add(passLabel);
            Controls.Add(passBox);
            Controls.Add(forgotPasswordLabel);
            Controls.Add(loginButton);
            Controls.Add(emailLabel);
            Controls.Add(emailBox);
            Name = "Form3";
            Text = "Forgot Password";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button loginButton;
        private Label emailLabel;
        private TextBox emailBox;
        private Label forgotPasswordLabel;
        private TextBox passBox;
        private Label passLabel;
        private Button changeButton;
    }
}