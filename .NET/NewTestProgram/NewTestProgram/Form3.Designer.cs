namespace NewTestProgram
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
            nameLabel = new Label();
            phoneBox = new TextBox();
            numberButton = new Button();
            verificationLabel = new Label();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(750, 9);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(38, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "label1";
            // 
            // phoneBox
            // 
            phoneBox.Location = new Point(12, 65);
            phoneBox.Name = "phoneBox";
            phoneBox.Size = new Size(140, 23);
            phoneBox.TabIndex = 1;
            // 
            // numberButton
            // 
            numberButton.Location = new Point(12, 94);
            numberButton.Name = "numberButton";
            numberButton.Size = new Size(87, 23);
            numberButton.TabIndex = 2;
            numberButton.Text = "Verify";
            numberButton.UseVisualStyleBackColor = true;
            numberButton.Click += button1_Click;
            // 
            // verificationLabel
            // 
            verificationLabel.AutoSize = true;
            verificationLabel.ForeColor = SystemColors.ControlDark;
            verificationLabel.Location = new Point(12, 120);
            verificationLabel.Name = "verificationLabel";
            verificationLabel.Size = new Size(120, 15);
            verificationLabel.TabIndex = 3;
            verificationLabel.Text = "Waiting for number...";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(verificationLabel);
            Controls.Add(numberButton);
            Controls.Add(phoneBox);
            Controls.Add(nameLabel);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private TextBox phoneBox;
        private Button numberButton;
        private Label verificationLabel;
    }
}