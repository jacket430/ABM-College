namespace dotNETFinal
{
    partial class NewTransaction
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
            propertyIDBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            ownerIDBox = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            amountBox = new TextBox();
            transactionTypeBox = new ComboBox();
            newButton = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // propertyIDBox
            // 
            propertyIDBox.FormattingEnabled = true;
            propertyIDBox.Location = new Point(12, 29);
            propertyIDBox.Name = "propertyIDBox";
            propertyIDBox.Size = new Size(106, 23);
            propertyIDBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 1;
            label1.Text = "PropertyID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(124, 11);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 3;
            label2.Text = "OwnerID:";
            // 
            // ownerIDBox
            // 
            ownerIDBox.FormattingEnabled = true;
            ownerIDBox.Location = new Point(124, 29);
            ownerIDBox.Name = "ownerIDBox";
            ownerIDBox.Size = new Size(121, 23);
            ownerIDBox.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 58);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(233, 23);
            dateTimePicker1.TabIndex = 4;
            // 
            // amountBox
            // 
            amountBox.Location = new Point(130, 87);
            amountBox.Name = "amountBox";
            amountBox.PlaceholderText = "Amount (ex: 100.00)";
            amountBox.Size = new Size(115, 23);
            amountBox.TabIndex = 6;
            // 
            // transactionTypeBox
            // 
            transactionTypeBox.FormattingEnabled = true;
            transactionTypeBox.Items.AddRange(new object[] { "Rent", "Buy" });
            transactionTypeBox.Location = new Point(12, 87);
            transactionTypeBox.Name = "transactionTypeBox";
            transactionTypeBox.Size = new Size(112, 23);
            transactionTypeBox.TabIndex = 7;
            transactionTypeBox.Text = "Transaction Type";
            // 
            // newButton
            // 
            newButton.Location = new Point(12, 116);
            newButton.Name = "newButton";
            newButton.Size = new Size(233, 46);
            newButton.TabIndex = 28;
            newButton.Text = "New Transaction";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += newButton_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 174);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(258, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 29;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // NewTransaction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 196);
            Controls.Add(statusStrip1);
            Controls.Add(newButton);
            Controls.Add(transactionTypeBox);
            Controls.Add(amountBox);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(ownerIDBox);
            Controls.Add(label1);
            Controls.Add(propertyIDBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "NewTransaction";
            Text = "Form1";
            Load += NewTransaction_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox propertyIDBox;
        private Label label1;
        private Label label2;
        private ComboBox ownerIDBox;
        private DateTimePicker dateTimePicker1;
        private TextBox amountBox;
        private ComboBox transactionTypeBox;
        private Button newButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}