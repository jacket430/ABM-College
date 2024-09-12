namespace dotNETFinal
{
    partial class EditOwner
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
            editButton = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            addressBox = new TextBox();
            emailBox = new TextBox();
            phoneNumberBox = new TextBox();
            lastNameBox = new TextBox();
            firstNameBox = new TextBox();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // editButton
            // 
            editButton.Location = new Point(12, 98);
            editButton.Name = "editButton";
            editButton.Size = new Size(233, 46);
            editButton.TabIndex = 34;
            editButton.Text = "Edit Owner";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 157);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(256, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 33;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // addressBox
            // 
            addressBox.Location = new Point(12, 69);
            addressBox.Name = "addressBox";
            addressBox.PlaceholderText = "Address (ex: 123 Address St NW)";
            addressBox.Size = new Size(233, 23);
            addressBox.TabIndex = 32;
            // 
            // emailBox
            // 
            emailBox.Location = new Point(131, 40);
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "Email Address";
            emailBox.Size = new Size(114, 23);
            emailBox.TabIndex = 31;
            // 
            // phoneNumberBox
            // 
            phoneNumberBox.Location = new Point(12, 40);
            phoneNumberBox.Name = "phoneNumberBox";
            phoneNumberBox.PlaceholderText = "Phone (4031234567)";
            phoneNumberBox.Size = new Size(113, 23);
            phoneNumberBox.TabIndex = 30;
            // 
            // lastNameBox
            // 
            lastNameBox.Location = new Point(131, 11);
            lastNameBox.Name = "lastNameBox";
            lastNameBox.PlaceholderText = "Last Name";
            lastNameBox.Size = new Size(114, 23);
            lastNameBox.TabIndex = 29;
            // 
            // firstNameBox
            // 
            firstNameBox.Location = new Point(12, 11);
            firstNameBox.Name = "firstNameBox";
            firstNameBox.PlaceholderText = "First Name";
            firstNameBox.Size = new Size(113, 23);
            firstNameBox.TabIndex = 28;
            // 
            // EditOwner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 179);
            Controls.Add(editButton);
            Controls.Add(statusStrip1);
            Controls.Add(addressBox);
            Controls.Add(emailBox);
            Controls.Add(phoneNumberBox);
            Controls.Add(lastNameBox);
            Controls.Add(firstNameBox);
            Name = "EditOwner";
            Text = "Edit Owner";
            Load += EditOwner_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button editButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TextBox addressBox;
        private TextBox emailBox;
        private TextBox phoneNumberBox;
        private TextBox lastNameBox;
        private TextBox firstNameBox;
    }
}