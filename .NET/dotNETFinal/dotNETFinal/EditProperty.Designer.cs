namespace dotNETFinal
{
    partial class EditProperty
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
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            label2 = new Label();
            label1 = new Label();
            typeBox = new ComboBox();
            editButton = new Button();
            stateBox = new ComboBox();
            dateBox = new DateTimePicker();
            descriptionBox = new TextBox();
            bedroomNumber = new NumericUpDown();
            bathroomNumber = new NumericUpDown();
            priceBox = new TextBox();
            zipBox = new TextBox();
            cityBox = new TextBox();
            addressBox = new TextBox();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bedroomNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bathroomNumber).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 255);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(253, 22);
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(130, 152);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 28;
            label2.Text = "Bathrooms:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 152);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 27;
            label1.Text = "Bedrooms:";
            // 
            // typeBox
            // 
            typeBox.FormattingEnabled = true;
            typeBox.Items.AddRange(new object[] { "Residential", "Commercial" });
            typeBox.Location = new Point(12, 97);
            typeBox.Name = "typeBox";
            typeBox.Size = new Size(88, 23);
            typeBox.TabIndex = 21;
            typeBox.Text = "Type";
            // 
            // editButton
            // 
            editButton.Location = new Point(12, 199);
            editButton.Name = "editButton";
            editButton.Size = new Size(233, 46);
            editButton.TabIndex = 26;
            editButton.Text = "Edit Entry";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // stateBox
            // 
            stateBox.FormattingEnabled = true;
            stateBox.Items.AddRange(new object[] { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" });
            stateBox.Location = new Point(118, 39);
            stateBox.Name = "stateBox";
            stateBox.Size = new Size(127, 23);
            stateBox.TabIndex = 18;
            stateBox.Text = "State";
            // 
            // dateBox
            // 
            dateBox.Location = new Point(106, 97);
            dateBox.Name = "dateBox";
            dateBox.Size = new Size(139, 23);
            dateBox.TabIndex = 22;
            // 
            // descriptionBox
            // 
            descriptionBox.Location = new Point(12, 126);
            descriptionBox.Name = "descriptionBox";
            descriptionBox.PlaceholderText = "Description";
            descriptionBox.Size = new Size(233, 23);
            descriptionBox.TabIndex = 23;
            // 
            // bedroomNumber
            // 
            bedroomNumber.Location = new Point(12, 170);
            bedroomNumber.Name = "bedroomNumber";
            bedroomNumber.Size = new Size(112, 23);
            bedroomNumber.TabIndex = 24;
            // 
            // bathroomNumber
            // 
            bathroomNumber.Location = new Point(130, 170);
            bathroomNumber.Name = "bathroomNumber";
            bathroomNumber.Size = new Size(115, 23);
            bathroomNumber.TabIndex = 25;
            // 
            // priceBox
            // 
            priceBox.Location = new Point(92, 68);
            priceBox.Name = "priceBox";
            priceBox.PlaceholderText = "Price (ex: 100000.00)";
            priceBox.Size = new Size(153, 23);
            priceBox.TabIndex = 20;
            // 
            // zipBox
            // 
            zipBox.Location = new Point(12, 68);
            zipBox.MaxLength = 5;
            zipBox.Name = "zipBox";
            zipBox.PlaceholderText = "Zip Code";
            zipBox.Size = new Size(74, 23);
            zipBox.TabIndex = 19;
            // 
            // cityBox
            // 
            cityBox.Location = new Point(12, 39);
            cityBox.Name = "cityBox";
            cityBox.PlaceholderText = "City";
            cityBox.Size = new Size(100, 23);
            cityBox.TabIndex = 17;
            // 
            // addressBox
            // 
            addressBox.Location = new Point(12, 10);
            addressBox.Name = "addressBox";
            addressBox.PlaceholderText = "Address (ex: 123 Example Street NW)";
            addressBox.Size = new Size(233, 23);
            addressBox.TabIndex = 16;
            // 
            // EditProperty
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(253, 277);
            Controls.Add(statusStrip1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(typeBox);
            Controls.Add(editButton);
            Controls.Add(stateBox);
            Controls.Add(dateBox);
            Controls.Add(descriptionBox);
            Controls.Add(bedroomNumber);
            Controls.Add(bathroomNumber);
            Controls.Add(priceBox);
            Controls.Add(zipBox);
            Controls.Add(cityBox);
            Controls.Add(addressBox);
            Name = "EditProperty";
            Text = "Form1";
            Load += EditProperty_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bedroomNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)bathroomNumber).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label label2;
        private Label label1;
        private ComboBox typeBox;
        private Button editButton;
        private ComboBox stateBox;
        private DateTimePicker dateBox;
        private TextBox descriptionBox;
        private NumericUpDown bedroomNumber;
        private NumericUpDown bathroomNumber;
        private TextBox priceBox;
        private TextBox zipBox;
        private TextBox cityBox;
        private TextBox addressBox;
    }
}