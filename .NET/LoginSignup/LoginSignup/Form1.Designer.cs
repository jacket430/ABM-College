namespace LoginSignup
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
            emailBox = new TextBox();
            passBox = new TextBox();
            confirmPassBox = new TextBox();
            emailLabel = new Label();
            passLabel = new Label();
            confirmLabel = new Label();
            submitButton = new Button();
            passErrorLabel = new Label();
            button1 = new Button();
            openLoginForm = new Button();
            SuspendLayout();
            // 
            // emailBox
            // 
            emailBox.Location = new Point(146, 12);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(148, 23);
            emailBox.TabIndex = 0;
            // 
            // passBox
            // 
            passBox.Location = new Point(146, 41);
            passBox.Name = "passBox";
            passBox.Size = new Size(148, 23);
            passBox.TabIndex = 1;
            // 
            // confirmPassBox
            // 
            confirmPassBox.Location = new Point(146, 70);
            confirmPassBox.Name = "confirmPassBox";
            confirmPassBox.Size = new Size(148, 23);
            confirmPassBox.TabIndex = 2;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(85, 15);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(39, 15);
            emailLabel.TabIndex = 3;
            emailLabel.Text = "Email:";
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Location = new Point(64, 44);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(60, 15);
            passLabel.TabIndex = 4;
            passLabel.Text = "Password:";
            // 
            // confirmLabel
            // 
            confirmLabel.AutoSize = true;
            confirmLabel.Location = new Point(17, 73);
            confirmLabel.Name = "confirmLabel";
            confirmLabel.Size = new Size(107, 15);
            confirmLabel.TabIndex = 5;
            confirmLabel.Text = "Confirm Password:";
            // 
            // submitButton
            // 
            submitButton.Location = new Point(130, 113);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(75, 23);
            submitButton.TabIndex = 6;
            submitButton.Text = "Register";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // passErrorLabel
            // 
            passErrorLabel.AutoSize = true;
            passErrorLabel.ForeColor = Color.Red;
            passErrorLabel.Location = new Point(146, 95);
            passErrorLabel.Name = "passErrorLabel";
            passErrorLabel.Size = new Size(140, 15);
            passErrorLabel.TabIndex = 7;
            passErrorLabel.Text = "Passwords do not match!";
            passErrorLabel.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(176, 142);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Print Dict";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openLoginForm
            // 
            openLoginForm.Location = new Point(211, 113);
            openLoginForm.Name = "openLoginForm";
            openLoginForm.Size = new Size(91, 23);
            openLoginForm.TabIndex = 9;
            openLoginForm.Text = "Open Login";
            openLoginForm.UseVisualStyleBackColor = true;
            openLoginForm.Click += openLoginForm_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 178);
            Controls.Add(openLoginForm);
            Controls.Add(button1);
            Controls.Add(passErrorLabel);
            Controls.Add(submitButton);
            Controls.Add(confirmLabel);
            Controls.Add(passLabel);
            Controls.Add(emailLabel);
            Controls.Add(confirmPassBox);
            Controls.Add(passBox);
            Controls.Add(emailBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox emailBox;
        private TextBox passBox;
        private TextBox confirmPassBox;
        private Label emailLabel;
        private Label passLabel;
        private Label confirmLabel;
        private Button submitButton;
        private Label passErrorLabel;
        private Button button1;
        private Button openLoginForm;
    }
}
