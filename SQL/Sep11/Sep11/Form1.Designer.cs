namespace Sep11
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
            checkoutButton = new Button();
            quantityBox = new NumericUpDown();
            dataGridView1 = new DataGridView();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            idBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            bulkButton = new Button();
            bulkErrorButton = new Button();
            bulkNameBox = new TextBox();
            bulkUpdateButton = new Button();
            ((System.ComponentModel.ISupportInitialize)quantityBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // checkoutButton
            // 
            checkoutButton.Location = new Point(319, 219);
            checkoutButton.Name = "checkoutButton";
            checkoutButton.Size = new Size(75, 23);
            checkoutButton.TabIndex = 0;
            checkoutButton.Text = "Checkout";
            checkoutButton.UseVisualStyleBackColor = true;
            checkoutButton.Click += checkoutButton_Click;
            // 
            // quantityBox
            // 
            quantityBox.Location = new Point(213, 233);
            quantityBox.Name = "quantityBox";
            quantityBox.Size = new Size(100, 23);
            quantityBox.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(382, 185);
            dataGridView1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 293);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(407, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // idBox
            // 
            idBox.Location = new Point(213, 204);
            idBox.Name = "idBox";
            idBox.Size = new Size(100, 23);
            idBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(159, 207);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 5;
            label1.Text = "Item ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(151, 235);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 6;
            label2.Text = "Quantity:";
            // 
            // bulkButton
            // 
            bulkButton.Location = new Point(124, 262);
            bulkButton.Name = "bulkButton";
            bulkButton.Size = new Size(132, 23);
            bulkButton.TabIndex = 7;
            bulkButton.Text = "Bulk Insert (100)";
            bulkButton.UseVisualStyleBackColor = true;
            bulkButton.Click += bulkButton_Click;
            // 
            // bulkErrorButton
            // 
            bulkErrorButton.Location = new Point(262, 262);
            bulkErrorButton.Name = "bulkErrorButton";
            bulkErrorButton.Size = new Size(132, 23);
            bulkErrorButton.TabIndex = 8;
            bulkErrorButton.Text = "Bulk Insert (w/ Error)";
            bulkErrorButton.UseVisualStyleBackColor = true;
            bulkErrorButton.Click += bulkErrorButton_Click;
            // 
            // bulkNameBox
            // 
            bulkNameBox.Location = new Point(12, 204);
            bulkNameBox.Name = "bulkNameBox";
            bulkNameBox.Size = new Size(122, 23);
            bulkNameBox.TabIndex = 9;
            // 
            // bulkUpdateButton
            // 
            bulkUpdateButton.Location = new Point(12, 233);
            bulkUpdateButton.Name = "bulkUpdateButton";
            bulkUpdateButton.Size = new Size(122, 23);
            bulkUpdateButton.TabIndex = 10;
            bulkUpdateButton.Text = "Bulk Update Names";
            bulkUpdateButton.UseVisualStyleBackColor = true;
            bulkUpdateButton.Click += bulkUpdateButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 315);
            Controls.Add(bulkUpdateButton);
            Controls.Add(bulkNameBox);
            Controls.Add(bulkErrorButton);
            Controls.Add(bulkButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(idBox);
            Controls.Add(statusStrip1);
            Controls.Add(dataGridView1);
            Controls.Add(quantityBox);
            Controls.Add(checkoutButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)quantityBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button checkoutButton;
        private NumericUpDown quantityBox;
        private DataGridView dataGridView1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TextBox idBox;
        private Label label1;
        private Label label2;
        private Button bulkButton;
        private Button bulkErrorButton;
        private TextBox bulkNameBox;
        private Button bulkUpdateButton;
    }
}
