namespace dotNETFinal
{
    partial class NewOwner
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
            firstNameBox = new TextBox();
            lastNameBox = new TextBox();
            phoneNumberBox = new TextBox();
            emailBox = new TextBox();
            addressBox = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            newButton = new Button();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // firstNameBox
            // 
            firstNameBox.Location = new Point(12, 12);
            firstNameBox.Name = "firstNameBox";
            firstNameBox.PlaceholderText = "First Name";
            firstNameBox.Size = new Size(113, 23);
            firstNameBox.TabIndex = 0;
            // 
            // lastNameBox
            // 
            lastNameBox.Location = new Point(131, 12);
            lastNameBox.Name = "lastNameBox";
            lastNameBox.PlaceholderText = "Last Name";
            lastNameBox.Size = new Size(114, 23);
            lastNameBox.TabIndex = 1;
            // 
            // phoneNumberBox
            // 
            phoneNumberBox.Location = new Point(12, 41);
            phoneNumberBox.Name = "phoneNumberBox";
            phoneNumberBox.PlaceholderText = "Phone (4031234567)";
            phoneNumberBox.Size = new Size(113, 23);
            phoneNumberBox.TabIndex = 2;
            // 
            // emailBox
            // 
            emailBox.Location = new Point(131, 41);
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "Email Address";
            emailBox.Size = new Size(114, 23);
            emailBox.TabIndex = 3;
            // 
            // addressBox
            // 
            addressBox.Location = new Point(12, 70);
            addressBox.Name = "addressBox";
            addressBox.PlaceholderText = "Address (ex: 123 Address St NW)";
            addressBox.Size = new Size(233, 23);
            addressBox.TabIndex = 4;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 157);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(256, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // newButton
            // 
            newButton.Location = new Point(12, 99);
            newButton.Name = "newButton";
            newButton.Size = new Size(233, 46);
            newButton.TabIndex = 27;
            newButton.Text = "New Owner";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += newButton_Click;
            // 
            // NewOwner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 179);
            Controls.Add(newButton);
            Controls.Add(statusStrip1);
            Controls.Add(addressBox);
            Controls.Add(emailBox);
            Controls.Add(phoneNumberBox);
            Controls.Add(lastNameBox);
            Controls.Add(firstNameBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "NewOwner";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Owner";
            Load += NewOwner_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox firstNameBox;
        private TextBox lastNameBox;
        private TextBox phoneNumberBox;
        private TextBox emailBox;
        private TextBox addressBox;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button newButton;
    }
}