namespace Question1
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
            userLoginBox = new TextBox();
            passLoginBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            loginButton = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            userRegBox = new TextBox();
            emailRegBox = new TextBox();
            regButton = new Button();
            label7 = new Label();
            passRegBox = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            aboutUsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // userLoginBox
            // 
            userLoginBox.Location = new Point(80, 50);
            userLoginBox.Name = "userLoginBox";
            userLoginBox.Size = new Size(100, 23);
            userLoginBox.TabIndex = 0;
            // 
            // passLoginBox
            // 
            passLoginBox.Location = new Point(80, 79);
            passLoginBox.Name = "passLoginBox";
            passLoginBox.Size = new Size(100, 23);
            passLoginBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 53);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 82);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(64, 112);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 32);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 7;
            label3.Text = "Login";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(282, 32);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 14;
            label4.Text = "Register";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(227, 82);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 11;
            label5.Text = "Username:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(251, 53);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 10;
            label6.Text = "Email:";
            // 
            // userRegBox
            // 
            userRegBox.Location = new Point(296, 79);
            userRegBox.Name = "userRegBox";
            userRegBox.Size = new Size(100, 23);
            userRegBox.TabIndex = 9;
            // 
            // emailRegBox
            // 
            emailRegBox.Location = new Point(296, 50);
            emailRegBox.Name = "emailRegBox";
            emailRegBox.Size = new Size(100, 23);
            emailRegBox.TabIndex = 8;
            // 
            // regButton
            // 
            regButton.Location = new Point(282, 137);
            regButton.Name = "regButton";
            regButton.Size = new Size(75, 23);
            regButton.TabIndex = 13;
            regButton.Text = "Register";
            regButton.UseVisualStyleBackColor = true;
            regButton.Click += regButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(230, 112);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 16;
            label7.Text = "Password:";
            // 
            // passRegBox
            // 
            passRegBox.Location = new Point(296, 108);
            passRegBox.Name = "passRegBox";
            passRegBox.Size = new Size(100, 23);
            passRegBox.TabIndex = 10;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 171);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(412, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 17;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(412, 24);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutUsToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // aboutUsToolStripMenuItem
            // 
            aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            aboutUsToolStripMenuItem.Size = new Size(123, 22);
            aboutUsToolStripMenuItem.Text = "About Us";
            aboutUsToolStripMenuItem.Click += aboutUsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(123, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 193);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(label7);
            Controls.Add(passRegBox);
            Controls.Add(label4);
            Controls.Add(regButton);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(userRegBox);
            Controls.Add(emailRegBox);
            Controls.Add(label3);
            Controls.Add(loginButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passLoginBox);
            Controls.Add(userLoginBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userLoginBox;
        private TextBox passLoginBox;
        private Label label1;
        private Label label2;
        private Button loginButton;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox userRegBox;
        private TextBox emailRegBox;
        private Button regButton;
        private Label label7;
        private TextBox passRegBox;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem aboutUsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}
