namespace LoginSignup
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
            emailBox = new TextBox();
            passBox = new TextBox();
            emailLabel = new Label();
            passLabel = new Label();
            loginButton = new Button();
            forgotPassButton = new Button();
            SuspendLayout();
            // 
            // emailBox
            // 
            emailBox.Location = new Point(78, 12);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(145, 23);
            emailBox.TabIndex = 0;
            // 
            // passBox
            // 
            passBox.Location = new Point(78, 41);
            passBox.Name = "passBox";
            passBox.Size = new Size(145, 23);
            passBox.TabIndex = 1;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(33, 15);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(39, 15);
            emailLabel.TabIndex = 2;
            emailLabel.Text = "Email:";
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Location = new Point(12, 44);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(60, 15);
            passLabel.TabIndex = 3;
            passLabel.Text = "Password:";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(33, 70);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // forgotPassButton
            // 
            forgotPassButton.Location = new Point(114, 70);
            forgotPassButton.Name = "forgotPassButton";
            forgotPassButton.Size = new Size(109, 23);
            forgotPassButton.TabIndex = 5;
            forgotPassButton.Text = "Forgot Password?";
            forgotPassButton.UseVisualStyleBackColor = true;
            forgotPassButton.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 107);
            Controls.Add(forgotPassButton);
            Controls.Add(loginButton);
            Controls.Add(passLabel);
            Controls.Add(emailLabel);
            Controls.Add(passBox);
            Controls.Add(emailBox);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox emailBox;
        private TextBox passBox;
        private Label emailLabel;
        private Label passLabel;
        private Button loginButton;
        private Button forgotPassButton;
    }
}